using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Core.Capabilities;
using CounterStrikeSharp.API.Modules.Commands;
using WASDSharedAPI;

namespace WasdSharedAPITest;

public class WasdTest : BasePlugin
{
    public override string ModuleName => "WasdMenuTest";
    public override string ModuleVersion => "1.0.0";
    public override string ModuleAuthor => "Interesting";

    public static IWasdMenuManager? MenuManager;
    
    public override void Load(bool hotReload)
    {
        
    }

    public IWasdMenuManager? GetMenuManager()
    {
        if (MenuManager == null)
            MenuManager = new PluginCapability<IWasdMenuManager>("wasdmenu:manager").Get();

        return MenuManager;
    }

    [ConsoleCommand("css_test_menu")]
    public void TestMenu(CCSPlayerController? player, CommandInfo? info)
    {
        var manager = GetMenuManager();
        if(manager == null)
            return;
        IWasdMenu menu = manager.CreateMenu("Test menu");
        menu.Add("Option 1", (p, option) =>
        {
            p.PrintToChat("You chose option 1!");
            manager.CloseMenu(p);
        });
        menu.Add("Option 2", (p, option) =>
        {
            p.PrintToChat("You chose option 2!");
            manager.CloseMenu(p);
        });
        IWasdMenu? subMenu = CreateTestSubMenu();
        if (subMenu != null)
        {
            subMenu.Prev = menu.Add("Sub menu 1", (p, option) =>
            {
                manager.OpenSubMenu(p, subMenu);
            });
        }

        menu.Add("sub menu 2", (p, option) =>
        {
            IWasdMenu? subMenu2 = CreateTestSubMenu();
            if(subMenu2 == null)
                manager.CloseMenu(p);
            else
            {
                subMenu2.Prev = option.Parent?.Options?.Find(option);
                manager.OpenSubMenu(p, subMenu2);
            }
        });

        manager.OpenMainMenu(player, menu);
    }

    public IWasdMenu? CreateTestSubMenu()
    {
        var manager = GetMenuManager();
        if(manager == null)
            return null;
        IWasdMenu sub = manager.CreateMenu("sub menu");
        sub.Add("sub option1", (player, option) =>
        {
            player.PrintToChat("you chose sub option 1");
            manager.CloseSubMenu(player);
        });
        sub.Add("sub option2", (player, option) =>
        {
            player.PrintToChat("you chose sub option 2");
            manager.CloseSubMenu(player);
        });
        return sub;
    }
}