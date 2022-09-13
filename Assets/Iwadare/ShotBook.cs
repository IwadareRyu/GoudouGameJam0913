using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBook : MonoBehaviour
{
    private GameObject _player;
    Vector3 _dir;
    float _speed = 10f;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _dir = (_player.transform.position - transform.position).normalized * _speed;
        _rb.AddForce(_dir,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
