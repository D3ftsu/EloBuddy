using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace SpaghettiAatrox
{
    class SpellManager
    {
        public static Spell.Skillshot Q, E;
        public static Spell.Active W, R;
        public static Spell.Targeted Ignite;

        public static void Init()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 650, SkillShotType.Circular, 600, 2000, 250)
            {
                AllowedCollisionCount = int.MaxValue,
                DamageType = DamageType.Physical
            };
            E = new Spell.Skillshot(SpellSlot.E, 1000, SkillShotType.Linear, 250, 1250, 35)
            {
                AllowedCollisionCount = int.MaxValue,
                DamageType = DamageType.Magical
            };
            W = new Spell.Active(SpellSlot.W);
            R = new Spell.Active(SpellSlot.R, 550)
            {
                DamageType = DamageType.Magical
            };
            Ignite = new Spell.Targeted(Player.Instance.GetSpellSlotFromName("SummonerDot"), 600);
        }
    }
}
