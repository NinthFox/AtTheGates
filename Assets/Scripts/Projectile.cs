using UnityEngine;
using System.Collections;

namespace ATG.Spells.Projectile{
    using NPC;
    public abstract class Projectile : MonoBehaviour, IProjectile {
        public float size;
        public float speed;
        public Vector3 target;
        public static GameObject projectileGO;
        public Spell spell;

        public delegate void ProjectileHitAction(NPC npc);
        public event ProjectileHitAction onProjectileHit;
        public delegate void ProjectileLaunchAction();
        public static event ProjectileLaunchAction onProjectileLaunched;

        public void OnImpact(NPC npc){
            onProjectileHit(npc);
        }

        private void moveTowardsTarget(){
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        public void OnLaunch(Spell spell){
            this.spell = spell;
            StartCoroutine(Move());
        }

        private IEnumerator Move(){
            while (Vector3.Distance(transform.position, target) > 0.1f)
            {
                Debug.Log("move towards " + target);
                moveTowardsTarget();
                yield return null;
            }
        }

        public void OnEnable(){
            onProjectileHit += ProjectileHit;
        }

        public void OnDisable(){
            onProjectileHit -= ProjectileHit;
        }
        public void ProjectileHit(NPC npc) {
            npc.Hit(this.spell);
            Destroy(this.gameObject);
        }

        public void OnTriggerEnter(Collider collider){
            if (collider.transform != this.spell.caster){
                NPC npc = collider.gameObject.GetComponent<NPC>();
                if (npc != null){
                    this.OnImpact(npc);
                    
                }
            }
        }

    }
}