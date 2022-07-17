using System;
using Managers;
using Signals;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class CollectablePhysicsController : MonoBehaviour
    {
        #region Self Variables
        #region Public Variables

        //public int index;
        
        #endregion
        #region Serialized Variables
        [SerializeField] private CollectableManager collectableManager;
        [SerializeField] private StackManager stackManager;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] public GameObject stackfizik;
        
        #endregion
        #region Private Variables
         public Vector3 pos;
        #endregion
        #endregion
        
        
        private void OnTriggerEnter(Collider other)
        { 
            if(other.CompareTag("Collectable"))
            { 
                CollectableSignals.Instance.onMoneyCollection?.Invoke();
                other.transform.parent=stackManager.transform;
                //other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
               // other.gameObject.GetComponent<Collider>().isTrigger = true;
                other.tag ="Collected";
                stackManager.Collected.Add(other.gameObject);
                

            }        
           if (other.CompareTag("Obstacle"))
           {
               var ChildCheck = transform.GetSiblingIndex();
               

               if (stackManager.Collected.Count - 1 == stackManager.Collected.IndexOf(this.gameObject)) //toplam sayı sonunca sayının ındexıne esıtse destroy, değilse ..
               {
                   stackManager.Collected.Remove(gameObject);
                   Destroy(gameObject);
                   CollectableSignals.Instance.onObstacleCollision?.Invoke();
                  }
               else
               {
                   int hitIndex = stackManager.Collected.IndexOf(this.gameObject);
                   int lastIndex = stackManager.Collected.Count - 1;
                  // Debug.Log(ChildCheck);
                   for (int i = hitIndex; i < lastIndex; i++)
                   {
                       stackManager.Collected.Remove(gameObject);
                       gameObject.tag = "Collectable";
                       GameObject newMoney = Instantiate(gameObject,
                           new Vector3(Random.Range(-9, -1), 0, Random.Range(50, 60))
                           ,Quaternion.identity);
                       
                       newMoney.transform.DOMove(
                           newMoney.transform.position - new Vector3(0, 2, 0), 1).SetEase(Ease.OutBounce);
                     //  Destroy(gameObject);

                       //TODO: birşeyler yapılacak
                       //TODO:for döngüsü, do move ileri atsın falan pişman.
                   }
               }
           }
        }
    }
}