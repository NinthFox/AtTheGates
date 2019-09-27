using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATG {
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance {get {
            return _instance;
        } }
        private static GameManager _instance;
        #endregion

        private float _generalTimeStamp;

        private void Awake() {
            _generalTimeStamp = 1;
            if (_instance != null && _instance != this)
            {
                Debug.LogWarning("GameManager instance already exists, deleting new one");
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
        }

        public float GetGeneralTimestamp(){
            return _generalTimeStamp;
        }

        public void SetGeneralTimestamp(float timestamp){
            _generalTimeStamp = timestamp;
        }
    }
}
