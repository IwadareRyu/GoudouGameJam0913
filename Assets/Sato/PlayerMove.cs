using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̈ړ��𐧌䂷��
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    PlayerInputEvent _pie;
    /// <summary>�v���C���[�̈ړ����x�̔{��</summary>
    [SerializeField] float _speedMag;
    /// <summary>�v���C���[�̉摜�̃A�j���[�^�[</summary>
    Animator _spriteAnim;
    /// <summary>���͂��ꂽ�ړ��x�N�g��</summary>
    Vector3 _velocity;
    /// <summary>�O�t���[���̈ړ��x�N�g��</summary>
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
