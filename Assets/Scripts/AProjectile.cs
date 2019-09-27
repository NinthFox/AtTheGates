using UnityEngine;
using System.Collections;

namespace ATG.Spells.Projectile{
    using NPC;
    public abstract class AProjectile : MonoBehaviour {
        public float size;
        public float speed;
        public Vector3 target;
        public static GameObject projectileGO;
        public Ability ability;

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
        public void OnLaunch(Ability ability){
            this.ability = ability;
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
            // npc.Hit(this.ability);
            Destroy(this.gameObject);
        }

        public void OnTriggerEnter(Collider collider){
            // if (collider.transform != this.ability.caster){
            //     NPC npc = collider.gameObject.GetComponent<NPC>();
            //     if (npc != null){
            //         this.OnImpact(npc);
                    
            //     }
            // }
        }

    }
}