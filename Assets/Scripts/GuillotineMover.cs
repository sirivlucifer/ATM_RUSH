using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GuillotineMover : MonoBehaviour
{
    [SerializeField] private Ease GuillotineMoverEase;
    private void Start()
    {
        transform.DORotate(new Vector3(0, 0, -90), 2, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo).SetEase(GuillotineMoverEase);
       //ransform.DORotate(new Vector3(0, 0, -90), 2).SetLoops(-1, LoopType.Yoyo);
    }
}
