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
            if (isCollected)
            {
                PullCollectedToStack();
            }
        }
        #endregion
        
        void OnMoneyCollection()
        {
            isCollected = true;
        }
        void PullCollectedToStack()
        {
            if (Colleted.Count > 1)
            {
                for (int i = 1; i < Colleted.Count; i++)
                {
                    var FirstCurrency = Colleted.ElementAt(i - 1);
                    var SecondCurrency = Colleted.ElementAt(i);
                    // var position = SecondCurrency.transform.position;
                    SecondCurrency.transform.position = new Vector3(Mathf.Lerp(SecondCurrency.transform.position.x,FirstCurrency.transform.position.x,15 * Time.deltaTime)
                        ,SecondCurrency.transform.position.y,Mathf.Lerp(SecondCurrency.transform.position.z,FirstCurrency.transform.position.z + 1.5f,15 * Time.deltaTime));
                }
            }
        }
    }
}