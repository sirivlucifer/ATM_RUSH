using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CardMover : MonoBehaviour
{
    [SerializeField] private Ease CardMoverEase;

    private void Start()
    {
        
        CardMoverr();
        
    }

    private void CardMoverr()
    {
        //transform.DOMoveX(transform.position.x - 10.8f, 2f).SetLoops(-1, LoopType.Yoyo);  // CardMover
        transform.DOMoveX(transform.position.x - 10.8f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(CardMoverEase);  // CardMover
        //transform.DOMoveX(transform.position.x - 5.4f, 2f).OnComplete(() => { transform.DOMoveX(transform.position.x + 10.8f, 2f); }).SetLoops(-1, LoopType.Yoyo);
    }
    
}