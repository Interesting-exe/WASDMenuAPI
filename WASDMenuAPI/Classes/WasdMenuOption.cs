using CounterStrikeSharp.API.Core;
using WASDMenuAPI.Classes;
using WASDSharedAPI;

namespace WASDMenuAPI;

public class WasdMenuOption : IWasdMenuOption
{
    public IWasdMenu? Parent { get; set; }
    public string? OptionDisplay { get; set; }
    public Action<CCSPlayerController, IWasdMenuOption>? OnChoose { get; set; }
    public int Index { get; set; }
}