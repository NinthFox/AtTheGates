using UnityEngine;

namespace ATG.Spells.Projectile{
    using NPC;
    interface IProjectile{
        void OnLaunch(Spell spell);
        void OnImpact(NPC npc);

    }
}