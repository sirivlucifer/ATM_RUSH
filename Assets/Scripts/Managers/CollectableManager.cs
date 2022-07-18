using System;
using System.Net.NetworkInformation;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class CollectableManager : MonoBehaviour
    {
        #region Self Variables
        #region Public Variables
        public CollectableType TypeData;
        public GameObject money;
        public GameObject gold;
        public GameObject diamond;
        #endregion
        #region Serialized Variables
       

        #endregion
        #region Private Variables

        #endregion


        #endregion
        #region Event Subscription

                private void OnEnable()
                {
                    SubscribeEvents();
                }
                private void SubscribeEvents()
                {
                    CollectableSignals.Instance.onMoneyCollection += OnMoneyCollection;
                    CollectableSignals.Instance.onObstacleCollision += OnObstacleCollision;

                }
        
                private void UnsubscribeEvents()
                { 
                    CollectableSignals.Instance.onMoneyCollection -= OnMoneyCollection;
                    CollectableSignals.Instance.onObstacleCollision -= OnObstacleCollision;
                }
        
                private void OnDisable()
                {
                    UnsubscribeEvents();
                } 

        #endregion


        private void Awake()
        {
            TypeData = GetCollectableStateData();
        }

        private CollectableType GetCollectableStateData() =>
            Resources.Load<CD_Collectable>("Data/CD_Collectable").CollectableData.CollectableType;
        

        private void OnMoneyCollection(GameObject self)
        {
           
        }
        private void OnObstacleCollision(GameObject self)
        {
            
        }
        public void OnUpgradeMoney()
        {
            OnChangeCollectableState(TypeData);
        }
        public void OnChangeCollectableState(CollectableType _collectableTypes)
        {
            if (_collectableTypes == CollectableType.Money)
            {
                TypeData = CollectableType.Gold;
                money.SetActive(false);
                gold.SetActive(true);
            }
        
            else if(_collectableTypes == CollectableType.Gold)
            {
                TypeData = CollectableType.Diamond;
                gold.SetActive(false);
                diamond.SetActive(true);
            }
        }
        
    }
}