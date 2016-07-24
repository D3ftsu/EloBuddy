using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using System.Linq;

namespace SpaghettiAatrox.Modes
{
    class PermaActive
    {
        private static AIHeroClient myHero = Player.Instance;

        public static void Execute()
        {
            Killsteal();
        }

        private static void Killsteal()
        {
            foreach (var enemy in EntityManager.Heroes.Enemies.Where(i => i.IsValidTarget()).ToList())
            {
                if (Config.KillstealMenu["Ignite"].Cast<CheckBox>().CurrentValue && SpellManager.Ignite.Slot != SpellSlot.Unknown && SpellManager.Ignite.CanCast(enemy) && enemy.Health+enemy.AttackShield+enemy.HPRegenRate*3 < myHero.GetSpellDamage(enemy, myHero.GetSpellSlotFromName("SummonerDot")))
                {
                    if (SpellManager.Ignite.Cast(enemy)) return;
                }
                if (Config.KillstealMenu["E"].Cast<CheckBox>().CurrentValue && SpellManager.E.CanCast(enemy) && enemy.Health + enemy.AllShield < myHero.GetSpellDamage(enemy, SpellSlot.E))
                {
                    if (SpellManager.E.Cast(enemy)) return;
                }
                if (Config.KillstealMenu["Q"].Cast<CheckBox>().CurrentValue && SpellManager.Q.CanCast(enemy) && enemy.Health + enemy.AttackShield < myHero.GetSpellDamage(enemy, SpellSlot.Q) && enemy.Position.CountEnemiesInRange(Config.KillstealMenu["QRange"].Cast<Slider>().CurrentValue) <= Config.KillstealMenu["QAround"].Cast<Slider>().CurrentValue)
                {
                    if (SpellManager.Q.Cast(enemy)) return;
                }
                if (Config.KillstealMenu["R"].Cast<CheckBox>().CurrentValue && SpellManager.R.CanCast(enemy) && enemy.Health + enemy.AllShield < myHero.GetSpellDamage(enemy, SpellSlot.R))
                {
                  if (SpellManager.R.Cast(enemy)) return;
                }
            }
        }
    }
}
