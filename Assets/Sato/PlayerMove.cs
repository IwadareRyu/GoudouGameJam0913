using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの移動を制御する
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    PlayerInputEvent _pie;
    /// <summary>プレイヤーの移動速度の倍率</summary>
    [SerializeField] float _speedMag;
    /// <summary>プレイヤーの画像のアニメーター</summary>
    Animator _spriteAnim;
    /// <summary>入力された移動ベクトル</summary>
    Vector3 _velocity;
    /// <summary>前フレームの移動ベクトル</summary>
    Vector3 _prevVelo;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pie = GetComponent<PlayerInputEvent>();
        _spriteAnim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        _velocity = new Vector3(hori, vert, 0);

        if (_prevVelo != _velocity)
        {
            if (hori == -1)
            {
                _spriteAnim.Play("Left");
                _pie.RayDir = -transform.right;
            }
            else if (hori == 1)
            {
                _spriteAnim.Play("Right");
                _pie.RayDir = transform.right;
            }
            else if (vert == 1)
            {
                _spriteAnim.Play("Up");
                _pie.RayDir = transform.up;
            }
            else if (vert == -1)
            {
                _spriteAnim.Play("Down");
                _pie.RayDir = -transform.up;
            }
        }

        _prevVelo = _velocity;
    }

    void FixedUpdate()
    {
        _rb.velocity = _velocity * _speedMag;
    }
}
