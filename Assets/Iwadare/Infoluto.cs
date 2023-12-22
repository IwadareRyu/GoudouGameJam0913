using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infoluto : MonoBehaviour
{
    Vector2 _senterPos;
    Vector2 _rotaPos;
    float _startTime;
    [SerializeField]float f = 1;
    float t;
    float radius = 0.1f;
    [SerializeField] float _coolTime = 3f;
    GameObject _warpMazzle;
    // Start is called before the first frame update
    void Start()
    {
        _senterPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _startTime = Time.time;
        _rotaPos = _senterPos;
        _rotaPos.x +=radius * Mathf.Sin(2 * Mathf.PI * f * _startTime);
        _rotaPos.y += radius * Mathf.Cos(2 * Mathf.PI * f * _startTime);
        radius += 0.005f;
        transform.position = _rotaPos;
        StartCoroutine(BreakTime());
    }
    IEnumerator BreakTime()
    {
        yield return new WaitForSeconds(_coolTime);
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
