using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HandMover : MonoBehaviour
{
    [SerializeField] private Ease HandMoverEase;
    private void Start()
    {
        HandMoverr();
    }
    private void HandMoverr()
    {
        transform.DOMoveX(transform.position.x - 5.4f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(HandMoverEase);  // HandMover
    }
}
