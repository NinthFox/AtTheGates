using UnityEngine;

namespace ATG.Abilities.Projectile{
    using NPC;
    interface IProjectile{
        void OnLaunch(Ability spell);
        void OnImpact(NPC npc);

    }
}