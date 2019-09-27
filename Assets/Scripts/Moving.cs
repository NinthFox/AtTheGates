using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace ATG {
    public class Moving : MonoBehaviour
    {

        public Animator animator;

        private ThirdPersonCharacter third;

        public bool isMoving;
        private Vector3 dest;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            third = GetComponent<ThirdPersonCharacter>();
            isMoving = false;
        }

        public void Move(Vector3 dest){
            isMoving = true;
            Player.Instance.agent.destination = dest;
            this.dest = dest;
        }

        void Update(){
            if (Player.Instance.agent.remainingDistance > Player.Instance.agent.stoppingDistance){
                third.Move(Player.Instance.agent.desiredVelocity, false, false);
            } else {
                isMoving = false;
                third.Move(Vector3.zero, false, false);
            }
        }


    }
}
