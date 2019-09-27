using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace ATG.Spells{

    public class UISpell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {

        private bool isPointerDown = false;
        private bool isPointerUp = false;

        private Image normalImg;
        private Image hoverImg;
        private Image onCastImg;
        private bool isHovering = false;
        public Ability ability;

        public ATG.NPC.NPC target;


        public void Initialize(){
            //Setup spells from a UISpellcontroller
            
            // spell = new Fireball();
            
        }

        public void OnPointerDown(PointerEventData pointer){
            isPointerDown = true;
            
        }

        public void OnPointerUp(PointerEventData pointer){
            if (isPointerDown){
                // Debug.Log("Launch spell");
                // spell = GetComponent<Fireball>();
                
                // isPointerDown = false;
                // //Launch spell
                // spell.setTarget(target.transform);
                // spell.caster = Player.Instance.transform;
                // spell.StartCasting();
            }
        }

        public void OnPointerExit(PointerEventData pointer){
            isPointerDown = false;
            isHovering = false;
            //Change image to normal one
        }

        public void OnPointerEnter(PointerEventData pointer){
            isHovering = true;
            //Change image to hover one
        }

        public void Update(){
            if (isHovering){
                
            }
        }
    }
}
