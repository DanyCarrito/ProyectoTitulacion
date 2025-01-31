using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOScale(2, 1)).Append(transform.DOScale(1, 1));
        //s.Append(transform.DORotate(Vector3.right*100,200).SetLoops(2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
