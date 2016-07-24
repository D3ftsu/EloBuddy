using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace SpaghettiAatrox.Modes
{
    class LaneClear
    {
        public static void Execute()
        {

            if (Config.LaneClearMenu["W"].Cast<CheckBox>().CurrentValue && SpellManager.W.IsReady())
            {
                if (Program.myHero.HealthPercent >= (Config.LaneClearMenu["HealPrio"].Cast<CheckBox>().CurrentValue ? 75 : Config.LaneClearMenu["Switch"].Cast<Slider>().CurrentValue))
                {
                    if (Program.myHero.Spellbook.GetSpell(SpellSlot.W).ToggleState == 1 && SpellManager.W.Cast()) return;
                }
                else if (Program.myHero.Spellbook.GetSpell(SpellSlot.W).ToggleState == 2 && SpellManager.W.Cast()) return;
            }

            if (Config.LaneClearMenu["E"].Cast<CheckBox>().CurrentValue && SpellManager.E.IsReady())
            {
                var pos = EntityManager.MinionsAndMonsters.GetLineFarmLocation(EntityManager.MinionsAndMonsters.GetLaneMinions(), SpellManager.E.Width, (int)SpellManager.E.Range);
                if (pos.HitNumber > 2 && SpellManager.E.Cast(pos.CastPosition)) return;
            }

            if (Config.LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue && SpellManager.Q.IsReady())
            {
                var pos = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(EntityManager.MinionsAndMonsters.GetLaneMinions(), SpellManager.Q.Width, (int)SpellManager.Q.Range);
                if (pos.HitNumber > 2 && SpellManager.Q.Cast(pos.CastPosition)) return;
            }

        }
    }
}
