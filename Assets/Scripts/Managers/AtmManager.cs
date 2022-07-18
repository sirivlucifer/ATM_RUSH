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
        void OnDeposit(GameObject gameObject)
        {
            AtmMoveDown(gameObject);
        }

        void AtmMoveDown(GameObject gameObject) {
             
             if (gameObject.CompareTag("Player"))
             {
                 transform.DOMoveY(-2.5f, 2f);
             }
            
             atmScoreController.OnDeposit(gameObject);
           
         }
    }
}

