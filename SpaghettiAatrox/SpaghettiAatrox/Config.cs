using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace SpaghettiAatrox
{
    class Config
    {
        public static Menu AatroxMenu, ComboMenu, HarassMenu, LaneClearMenu, KillstealMenu, AntiGapcloserMenu, InterrupterMenu, DrawingsMenu;

        public static void Init()
        {
            AatroxMenu = MainMenu.AddMenu("Spaghetti Series : Aatrox", "SpaghettiAatrox");
            AatroxMenu.AddLabel("A spaghetti code is almost impossible to debug and maintain, and rarely works well...");
            AatroxMenu.AddLabel("but somehow Spaghetti Series works flawlessly :P, and this was my first C# addon ^^");
            AatroxMenu.AddLabel("make sure to drop upvote on the thread and DB :)");

            ComboMenu = AatroxMenu.AddSubMenu("Combo", "Combo");
            ComboMenu.Add("Q", new CheckBox("Use Q"));
            ComboMenu.Add("W", new CheckBox("Use W"));
            ComboMenu.Add("Switch", new Slider("Switch To Heal Mode If HP% <", 50, 0, 100));
            ComboMenu.Add("E", new CheckBox("Use E"));
            ComboMenu.Add("R", new CheckBox("Use R"));
            ComboMenu.Add("RHP", new Slider("Use R If Enemy HP% <", 60, 0, 100));
            ComboMenu.Add("RCount", new Slider("Minimum Enemies Around", 1, 1, 5));

            HarassMenu = AatroxMenu.AddSubMenu("Harass", "Harass");
            HarassMenu.Add("Q", new CheckBox("Use Q"));
            HarassMenu.Add("E", new CheckBox("Use E"));

            LaneClearMenu = AatroxMenu.AddSubMenu("LaneClear", "LaneClear");
            LaneClearMenu.Add("Q", new CheckBox("Use Q", false));
            LaneClearMenu.Add("W", new CheckBox("Use W"));
            LaneClearMenu.Add("HealPrio", new CheckBox("Heal Priority"));
            LaneClearMenu.Add("Switch", new Slider("Switch To Heal Mode If HP% <", 50, 0, 100));
            LaneClearMenu.Add("E", new CheckBox("Use E"));

            KillstealMenu = AatroxMenu.AddSubMenu("Killsteal", "Killsteal");
            if (SpellManager.Ignite.Slot != SpellSlot.Unknown) KillstealMenu.Add("Ignite", new CheckBox("Use Ignite"));
            KillstealMenu.Add("Q", new CheckBox("Use Q"));
            KillstealMenu.Add("QAround", new Slider("Only if Enemies Around Target <=", 2, 0, 4));
            KillstealMenu.Add("QRange", new Slider("Q Range Check", 600, 0, 1000));
            KillstealMenu.Add("E", new CheckBox("Use E"));
            KillstealMenu.Add("R", new CheckBox("Use R"));

            AntiGapcloserMenu = AatroxMenu.AddSubMenu("AntiGapcloser", "AntiGapcloser");
            AntiGapcloserMenu.AddLabel("Configure Gapcloser Spells At 'Core -> Gapcloser'");
            AntiGapcloserMenu.Add("Enabled", new CheckBox("Enabled"));

            InterrupterMenu = AatroxMenu.AddSubMenu("Interrupter", "Interrupter");
            InterrupterMenu.AddLabel("Configure Interrupter Spells At 'Core -> Interrupter'");
            InterrupterMenu.Add("Enabled", new CheckBox("Enabled"));

            DrawingsMenu = AatroxMenu.AddSubMenu("Drawings", "Drawings");
            DrawingsMenu.Add("OnlyReady", new CheckBox("Only Ready Spells", false));
            DrawingsMenu.Add("Q", new CheckBox("Draw Q Range"));
            DrawingsMenu.Add("E", new CheckBox("Draw E Range"));
            DrawingsMenu.Add("R", new CheckBox("Draw R Range"));
        }
    }
}
