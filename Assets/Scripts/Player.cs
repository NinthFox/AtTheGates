﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;

namespace ATG{

    public class Player : MonoBehaviour
    {
        #region Singleton
        public static Player Instance {get {return _instance;} }
        private static Player _instance;
        #endregion

        public CinemachineFreeLook playerCamera;
        public Transform playerCharacter;
        public NavMeshAgent agent;
        public Animator animator;
        public Moving moving;

        public bool isFocusing {get {
            return Focus.isFocusing;
        }}

        public float FocusAmount{
            get {
                return _focusAmount;
            }
        }

        [SerializeField]
        private float _focusAmount = 0.5f;
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Debug.LogWarning("Player instance already exists, deleting new one");
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
            playerCamera = transform.GetChild(0).GetComponent<CinemachineFreeLook>();
            if (playerCamera == null){
                Debug.LogWarning("Ttension y'a pas de camera");
            }
            playerCharacter = transform.GetChild(1);
            agent = playerCharacter.GetComponent<NavMeshAgent>();
            animator = playerCharacter.GetComponent<Animator>();
        }

    }
}
