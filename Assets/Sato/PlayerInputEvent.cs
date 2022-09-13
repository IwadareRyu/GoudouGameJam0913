using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入力があったらプレイヤーがイベントを起こす
/// </summary>
public class PlayerInputEvent : MonoBehaviour
{
    /// <summary>レイがヒットするレイヤー</summary>
    [SerializeField] LayerMask _mask;
    /// <summary>レイの長さ</summary>
    [SerializeField] int _rayDist;
    /// <summary>イベントがヒットしたときのマーク</summary>
    [SerializeField] GameObject _hitMark;

    /// <summary>レイを飛ばす向き</summary>
    public Vector3 RayDir { get; set; }


    void Start()
    {
        
    }

    void Update()
    {
        // 指定された方向にRayを飛ばす
        RaycastHit2D hit = Physics2D.Raycast(transform.position, RayDir.normalized, _rayDist, _mask);
        if (hit.collider != null)
        {
            if (_hitMark.activeSelf == false) _hitMark.SetActive(true);
            if (Input.GetButtonDown("Submit"))
            {
                Debug.Log("イベント実行");
            }
        }
        else
        {
            if (_hitMark.activeSelf == true) _hitMark.SetActive(false);
        }
    }
}
