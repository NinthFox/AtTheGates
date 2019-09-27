using System;
using UnityEngine;
using System.Collections.Generic;

namespace ATG.Spells{
    public interface ISpell {
        void OnDamage();
        void OnKill();
        void OnStartIncant();
        void OnEndIncant();
        void StartCasting();
        void OnEndCasting();
    }
}