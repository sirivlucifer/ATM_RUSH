using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallMover : MonoBehaviour
{
  
    private void Start()
    {
        WallMoverr();
    }
    private void WallMoverr()
    {
        transform.DORotate(new Vector3(0, 3600, 0), 20, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}