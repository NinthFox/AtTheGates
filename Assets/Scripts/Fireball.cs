using UnityEngine;
using System.Collections;

using ATG.Spells.Projectile;

namespace ATG.Spells{
    public class Fireball : Spell {
        public float channelingSpeed = 0.2f;

        public FireballProjectile projectile;
        private static GameObject fireballGO;
        public Transform target;

        //TEMPORARAY
        public override void setTarget(Transform target){
            this.target = target;
        }

        public static void Initialize(){
            fireballGO = Resources.Load<GameObject>("Abilities/Projectiles/Fireball");
        }
        public override void OnDamage(){
            Debug.Log("Damage effects from spell whouushh shouuu waza");
        }
        public override void OnKill(){
            Debug.Log("Kill the enemy");
        }

        public override void OnEndCasting(){}
        public override void OnStartIncant(){
            //Instantiate()
            fireballGO = Resources.Load<GameObject>("Abilities/Projectiles/Fireball");

            projectile = Instantiate(fireballGO, Player.Instance.transform).GetComponent<FireballProjectile>();
            if (projectile != null){
                projectile.target = this.target.position;
                projectile.OnLaunch(this);
                
            }
            //LaunchFireball();
        }

        public override void StartCasting(){
            OnStartIncant();
            //Show selection interface and make target selection waiting StartIncant callback
        }

        public override void OnEndIncant(){

        }
    }
}