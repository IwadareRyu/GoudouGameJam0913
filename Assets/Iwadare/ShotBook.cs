using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBook : MonoBehaviour
{
    private GameObject _player;
    Vector3 _dir;
    [SerializeField]float _speed = 10f;
    Rigidbody2D _rb;
    GameObject _warpMazzle;

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
        StartCoroutine(BreakTime());
    }
    
    IEnumerator BreakTime()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _warpMazzle = GameObject.FindGameObjectWithTag("Warp");
            collision.transform.position = _warpMazzle.transform.position;
        }
    }
}
