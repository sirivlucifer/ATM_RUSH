using System;
using Controllers;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Managers
{
    public class AtmManager : MonoBehaviour
    {
        public AtmScoreController atmScoreController;
        public int atmId;
        public Collider Collider;
        private int instanceId;

        private void Awake()
        {
            instanceId = GetComponent<AtmManager>().GetInstanceID();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }
    
        private void SubscribeEvents()
        {
            CollectableSignals.Instance.onDeposit += OnDeposit;

        }
        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onDeposit -= OnDeposit;
    
        }
        private void OnDisable()
        {
            UnsubscribeEvents();
        } 
        void OnDeposit(GameObject gameObject, int InstanceID)
        {
            
            AtmMoveDown(gameObject,InstanceID);
            
               
        }

        void AtmMoveDown(GameObject gameObject,int InstanceID) {

            if (InstanceID == instanceId)
            {
                 if (gameObject.CompareTag("Player"))
                 {
                     transform.DOMoveY(-3f, 2f).SetEase(Ease.OutBounce);
                }
                 atmScoreController.OnDeposit(gameObject);
            }
            
            
        }
    }
}

