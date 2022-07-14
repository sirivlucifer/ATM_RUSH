﻿using System;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class CollectablePhysicsController : MonoBehaviour
    {
        
        
        #region Self Variables
        #region Public Variables
        #endregion
        #region Serialized Variables
        [SerializeField] private CollectableManager collectableManager;
        [SerializeField] private StackManager stackManager;
        #endregion
        #endregion
        private void OnTriggerEnter(Collider other)
        { 
            if(other.CompareTag("Collectable"))
            {
                CollectableSignals.Instance.onMoneyCollection?.Invoke();
                other.transform.parent = stackManager.transform;
                other.tag ="Collected";
                stackManager.Colleted.Add(other.gameObject);
            }
        }
    }
}