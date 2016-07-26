using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace SpaghettiAatrox.Modes
{
    class Combo
    {
        public static void Execute()
        {

            if (Config.ComboMenu["W"].Cast<CheckBox>().CurrentValue && SpellManager.W.IsReady() && Program.myHero.Position.CountEnemiesInRange(Program.myHero.GetAutoAttackRange()) > 0)
            {
                if (Program.myHero.HealthPercent >= Config.ComboMenu["Switch"].Cast<Slider>().CurrentValue)
                {
                    if (Program.myHero.Spellbook.GetSpell(SpellSlot.W).ToggleState == 1 && SpellManager.W.Cast()) return;
                }
                else if (Program.myHero.Spellbook.GetSpell(SpellSlot.W).ToggleState == 2 && SpellManager.W.Cast()) return;
            } 

            var Rtarget = SpellManager.R.GetTarget();
            if (Config.ComboMenu["R"].Cast<CheckBox>().CurrentValue && SpellManager.R.CanCast(Rtarget) && (Rtarget.Health + Rtarget.AllShield < Program.myHero.GetSpellDamage(Rtarget, SpellSlot.R) || Rtarget.HealthPercent <= Config.ComboMenu["RHP"].Cast<Slider>().CurrentValue) && Program.myHero.CountEnemiesInRange(SpellManager.R.Range) >= Config.ComboMenu["RAround"].Cast<Slider>().CurrentValue)
            {
                if (SpellManager.R.Cast()) return;
            }

            var Qtarget = SpellManager.Q.GetTarget();
            if (Config.ComboMenu["Q"].Cast<CheckBox>().CurrentValue && SpellManager.Q.CanCast(Qtarget))
            {
                if (SpellManager.Q.Cast(Qtarget)) return;
            }

            var Etarget = SpellManager.E.GetTarget();
            if (Config.ComboMenu["E"].Cast<CheckBox>().CurrentValue && SpellManager.E.CanCast(Etarget))
            {
                if (SpellManager.E.Cast(Etarget)) return;
            }
        }
    }
}