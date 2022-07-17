using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObstacleMover : MonoBehaviour
{
    
    
    private void Start()
    {
        

        transform.DOMoveX(transform.position.x - 10.8f, 2f).SetLoops(-1, LoopType.Yoyo);
        //transform.DOMoveX(transform.position.x - 5.4f, 2f).OnComplete(() => { transform.DOMoveX(transform.position.x + 10.8f, 2f); }).SetLoops(-1, LoopType.Yoyo);
    }
}