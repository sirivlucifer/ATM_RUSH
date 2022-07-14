using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Extentions;
using Signals;
using UnityEngine;
namespace Managers
{ 
    public class StackManager : MonoSingleton<StackManager>
    {
        public List<GameObject> Colleted;
        private bool isCollected;
        #region Event Subscriptions
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CollectableSignals.Instance.onMoneyCollection += OnMoneyCollection;
        }

        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onMoneyCollection -= OnMoneyCollection;
        } private void OnDisable()
        {
            UnsubscribeEvents();
        } 
        private void Update()
        {
            PullCollectedToStack();
        }
        #endregion
        
        void OnMoneyCollection()
        {
            isCollected = true;
        }
        void PullCollectedToStack()
        {
            if(!isCollected) return;
            {
                 if (Colleted.Count > 1)
                 {
                     for (int i = 1; i < Colleted.Count; i++)
                     {
                         var FirstCollectable = Colleted.ElementAt(i-1);
                         var SecondCollectable = Colleted.ElementAt(i);
                         var FollowerPosition = SecondCollectable.transform.position;
                         var TargetPosition = FirstCollectable.transform.position;
                         var LerpVector = new Vector3(Mathf.Lerp(FollowerPosition.x,TargetPosition.x,15 * Time.deltaTime)
                             ,FollowerPosition.y,Mathf.Lerp(FollowerPosition.z,TargetPosition.z + 1.5f,15 * Time.deltaTime));
                         
                         SecondCollectable.transform.position = LerpVector;
                     }
                 }
            }
        }
    }
}