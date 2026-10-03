// ReSharper disable UnusedType.Global
using System;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using LabApi.Features.Console;

namespace LACassie;

public class Plugin : Plugin<Config>
{
    public override string Name { get; } = "LACassie";
    public override string Description { get; } = "Allows using CASSIE in Local Admin";
    public override string Author { get; } = "NameDuckling770";
    public override Version Version { get; } = new Version(1, 1, 0, 0);
    public override Version RequiredApiVersion { get; } = new Version(LabApiProperties.CompiledVersion);
    public static Plugin Main { get; private set; } = null;
    
    public override void Enable()
    {
        Main = this;
        Logger.Info("LACassie started.");
        if (this.Config.DebugMode) Logger.Debug($"LACassie version: {this.Version}");
    }

    public override void Disable()
    {
        Main = null;
    }
}