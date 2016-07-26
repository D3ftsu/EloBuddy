using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using SpaghettiAatrox.Modes;

namespace SpaghettiAatrox
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += evt_OnLoad;
        }

        public static AIHeroClient myHero { get { return Player.Instance; } }

        private static void evt_OnLoad(EventArgs args)
        {
            if (myHero.ChampionName != "Aatrox") return;
            SpellManager.Init();
            Config.Init();
            Game.OnTick += evt_OnTick;
            Drawing.OnDraw += evt_OnDraw;
            Gapcloser.OnGapcloser += evt_OnGapCloser;
            Interrupter.OnInterruptableSpell += evt_OnInterrupt;
        }

        private static void evt_OnDraw(EventArgs args)
        {
            if (Config.DrawingsMenu["Q"].Cast<CheckBox>().CurrentValue && (!Config.DrawingsMenu["OnlyReady"].Cast<CheckBox>().CurrentValue || SpellManager.Q.IsReady()))
            {
                Circle.Draw(SpellManager.Q.IsReady() ? Color.Chartreuse : Color.OrangeRed, SpellManager.Q.Range, myHero);
            }
            if (Config.DrawingsMenu["E"].Cast<CheckBox>().CurrentValue && (!Config.DrawingsMenu["OnlyReady"].Cast<CheckBox>().CurrentValue || SpellManager.E.IsReady()))
            {
                Circle.Draw(SpellManager.E.IsReady() ? Color.Chartreuse : Color.OrangeRed, SpellManager.E.Range, myHero);
            }
            if (Config.DrawingsMenu["R"].Cast<CheckBox>().CurrentValue && (!Config.DrawingsMenu["OnlyReady"].Cast<CheckBox>().CurrentValue || SpellManager.R.IsReady()))
            {
                Circle.Draw(SpellManager.R.IsReady() ? Color.Chartreuse : Color.OrangeRed, SpellManager.R.Range, myHero);
            }
        }

        private static void evt_OnTick(EventArgs args)
        {
            if (myHero.IsDead) return;
 
            PermaActive.Execute();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
              Combo.Execute();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                Harass.Execute();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                LaneClear.Execute();
        }

        private static void evt_OnInterrupt(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (Config.InterrupterMenu["Enabled"].Cast<CheckBox>().CurrentValue && sender.IsEnemy && SpellManager.Q.IsReady())
            {
                SpellManager.Q.Cast(sender);
            }
        }

        private static void evt_OnGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (Config.AntiGapcloserMenu["Enabled"].Cast<CheckBox>().CurrentValue && sender.IsEnemy && SpellManager.Q.IsReady())
            {
                SpellManager.Q.Cast(sender);
            }
        }
    }
}
