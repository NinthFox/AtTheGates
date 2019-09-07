using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace ATG.Spells{
    public abstract class Spell : MonoBehaviour, ISpell {
        public string spellName;
        public List<SpellType> spellType;
        public float damage;
        public float castTime;
        public float manaCost;
        public float energyCost;
        public float movementModifier;
        public Transform caster;

        public delegate Event onStartCasting();

        public abstract void OnDamage();
        public abstract void OnKill();
        public abstract void OnStartIncant();
        public abstract void OnEndIncant();
        public abstract void StartCasting();
        public abstract void OnEndCasting();

        //Temporary
        public abstract void setTarget(Transform target);

        // public Spell Init(){
        //     return Instantiate();
        // }
    }

}