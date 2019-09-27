using UnityEngine;

namespace ATG{
    public static class Focus {

        public static bool isFocusing = false;
        private static float _generalTimeStamp {get {
            return GameManager.Instance.GetGeneralTimestamp();
        }}

        public static void StartFocus(){
            isFocusing = true;
            Time.timeScale = 1 - Player.Instance.FocusAmount;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        public static void StopFocus(){
            isFocusing = false;
            Time.timeScale = _generalTimeStamp;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        public static void TriggerFocus(){
            if (isFocusing){
                StopFocus();
            } else {
                StartFocus();
            }
        }
    }
}