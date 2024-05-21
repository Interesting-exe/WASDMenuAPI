using CounterStrikeSharp.API.Core;

namespace WASDSharedAPI;

public interface IWasdMenuManager
{
    //open the menu as main menu
    public void OpenMainMenu(CCSPlayerController? player, IWasdMenu? menu);
    //close all menus
    public void CloseMenu(CCSPlayerController? player);
    //close current submenu and go to previous menu/submenu
    public void CloseSubMenu(CCSPlayerController? player);
    //close all submenus and go to main menu
    public void CloseAllSubMenus(CCSPlayerController? player);
    //open menu as submenu
    public void OpenSubMenu(CCSPlayerController? player, IWasdMenu? menu);
    //create new menu object
    public IWasdMenu CreateMenu(string title = "");
}