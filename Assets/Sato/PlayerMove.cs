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
    /// <summary>�v���C���[�̈ړ����x�̔{��</summary>
    [SerializeField] float _speedMag;
    /// <summary>���͂Ő��䂷��A�j���[�^�[</summary>
    [SerializeField] Animator _spriteAnim;
    /// <summary>���͂��ꂽ�x�N�g��</summary>
    Vector3 _velocity;
    /// <summary>�O�̃t���[���̈ړ�</summary>
    Vector3 _prevVelo;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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
            }
            else if (hori == 1)
            {
                _spriteAnim.Play("Right");
            }
            else if (vert == 1)
            {
                _spriteAnim.Play("Up");
            }
            else if (vert == -1)
            {
                _spriteAnim.Play("Down");
            }
        }
        _prevVelo = _velocity;
    }

    void FixedUpdate()
    {
        _rb.velocity = _velocity * _speedMag;
    }
}
