using System.ComponentModel;

namespace LACassie;

public class Config
{
    [Description("Enable debug outputs (default: false)")]
    public bool DebugMode { get; } = false;
}