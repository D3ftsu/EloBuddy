using EloBuddy.SDK.Menu.Values;

namespace SpaghettiAatrox.Modes
{
    class Harass
    {
        public static void Execute()
        {
            var Qtarget = SpellManager.Q.GetTarget();
            if (Config.HarassMenu["Q"].Cast<CheckBox>().CurrentValue && SpellManager.Q.CanCast(Qtarget))
            {
                if (SpellManager.Q.Cast(Qtarget)) return;
            }

            var Etarget = SpellManager.E.GetTarget();
            if (Config.HarassMenu["E"].Cast<CheckBox>().CurrentValue && SpellManager.E.CanCast(Etarget))
            {
                if (SpellManager.E.Cast(Etarget)) return;
            }
        }
    }
}