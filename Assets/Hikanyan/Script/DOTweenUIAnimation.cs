using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DOTweenUIAnimation : MonoBehaviour
{
    [SerializeField] Transform _parentTransform;
    private void Awake()
    {

        foreach (Transform childTransfom in _parentTransform)
        {

            childTransfom.transform.DOLocalMoveX(0.2f, 6f)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}
