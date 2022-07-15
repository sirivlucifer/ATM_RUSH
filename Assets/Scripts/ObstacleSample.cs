using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Managers;
using DG.Tweening;

public class ObstacleSample : MonoBehaviour
{
    //public StackManager stackList;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            if (StackManager.Instance.Colleted.Count -1 == StackManager.Instance.Colleted.IndexOf(other.gameObject))
            {
                StackManager.Instance.Colleted.Remove(other.gameObject);
                Destroy(other.gameObject);
            }
            
        }
        //else if (other.CompareTag("Player"))
        //{

        //    other.transform.DOMove(other.transform.position - new Vector3(0, 0, 20), 1).SetEase(Ease.OutBounce);
        //}
    }
    
    
    
}

         

