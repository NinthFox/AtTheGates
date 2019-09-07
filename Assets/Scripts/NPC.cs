using UnityEngine;
namespace ATG.NPC{
    using ATG.Spells;
    public class NPC : MonoBehaviour {
        public void Hit(Spell spell){
            Debug.Log("hit " + gameObject.name);
            Debug.Log("Did " + spell.damage + " damage");
            Debug.Log("Of type " + spell.spellType.ToString());
            spell.OnDamage();
        }
    }
}