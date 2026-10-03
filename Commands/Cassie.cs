// ReSharper disable InconsistentNaming
// ReSharper disable HeuristicUnreachableCode
// ReSharper disable UnusedType.Global
#pragma warning disable CS0162
using System;
using CommandSystem;
using Cassie;
using LabApi.Features.Console;
using LabApi.Features.Wrappers;
using LACassie;

namespace LACassie.Commands;

[CommandHandler(typeof(GameConsoleCommandHandler))]
public class LACassie : ICommand
{
    public string Command { get; } = "lacassie";
    public string[] Aliases { get; } = { "lac", "cassie" };
    public string Description { get; } = "Make CASSIE say something";
    
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        // throw new NotImplementedException("This command is still being made");
        if (arguments.Count < 1)
        {
            response = "Usage: lacassie <announcement>";
            return false;
        }
        var message = string.Join(" ", arguments);
        var ttsPayload = new CassieTtsPayload(message, true, true);
        if (Plugin.Main.Config.DebugMode) Logger.Debug("Sending CASSIE announcement");
        Announcer.Message(ttsPayload);
        response = "Announcement sent.";
        return true;
    }
}

[CommandHandler(typeof(GameConsoleCommandHandler))]
public class LACassieSilent : ICommand
{
    public string Command { get; } = "lacassiesilent";
    public string[] Aliases { get; } = { "lacs", "lacassie_silent", "cassie_sl" };
    public string Description { get; } = "Make CASSIE say something, but without the static and chimes";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        // throw new NotImplementedException("This command is still being made");
        if (arguments.Count < 1)
        {
            response = "Usage: lacassiesilent <announcement>";
            return false;
        }
        var message = string.Join(" ", arguments);
        var ttsPayload = new CassieTtsPayload(message, true, false);
        if (Plugin.Main.Config.DebugMode) Logger.Debug("Sending CASSIE silent announcement");
        Announcer.Message(ttsPayload);
        response = "Announcement sent.";
        return true;
    }
}

[CommandHandler(typeof(GameConsoleCommandHandler))]
public class LACassieSubtitles : ICommand
{
    public string Command { get; } = "lacassiesubtitles";
    public string[] Aliases { get; } = { "lacsub", "lacassie_subtitles", "cassie_subtitles" };
    public string Description { get; } = "Make CASSIE say something, but with custom subtitles";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        // throw new NotImplementedException("This command is still being tested");
        if (arguments.Count < 2)
        {
            response = "Usage: lacassiesubtitles \"<announcement>\" \"<subtitles>\" \nEx: lacassiesubtitles \"HELLO WORLD\" \"Hello, World!\"";
            return false;
        }

        var message = arguments.At(0);
        var subtitles = arguments.At(1);
        var ttsPayload = new CassieTtsPayload(message, subtitles, true);
        if (Plugin.Main.Config.DebugMode) Logger.Debug("Sending CASSIE announcement with subtitles");
        Announcer.Message(ttsPayload);
        response = "Announcement with subtitles sent.";
        return true;
    }
}

[CommandHandler(typeof(GameConsoleCommandHandler))]
public class LACassieSubtitlesSilent : ICommand
{
    public string Command { get; } = "lacassiesubtitlessilent";
    public string[] Aliases { get; } = { "lacsubs", "lacassie_subtitlessilent", "cassie_sl_subtitles" };
    public string Description { get; } = "Make CASSIE say something, but with custom subtitles and without the static and chimes";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        // throw new NotImplementedException("This command is still being tested");
        if (arguments.Count < 2)
        {
            response = "Usage: lacassiesubtitlessilent \"<announcement>\" \"<subtitles>\" \nEx: lacassiesubtitles \"HELLO WORLD\" \"Hello, World!\"";
            return false;
        }

        var message = arguments.At(0);
        var subtitles = arguments.At(1);
        var ttsPayload = new CassieTtsPayload(message, subtitles, false);
        if (Plugin.Main.Config.DebugMode) Logger.Debug("Sending CASSIE silent announcement with subtitles");
        Announcer.Message(ttsPayload);
        response = "Announcement with subtitles sent.";
        return true;
    }
}

[CommandHandler(typeof(GameConsoleCommandHandler))]
public class LACassieClear : ICommand
{
    public string Command { get; } = "lacassieclear";
    public string[] Aliases { get; } = { "lacc", "lacassie_clear", "laclearcassie" };
    public string Description { get; } = "Clear the CASSIE queue";
    
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (Plugin.Main.Config.DebugMode) Logger.Debug("Clearing CASSIE queue");
        Announcer.Clear();
        response = "Cleared CASSIE queue";
        return true;
    }
}