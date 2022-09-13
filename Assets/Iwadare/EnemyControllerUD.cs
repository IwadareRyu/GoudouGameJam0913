using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerUD : MonoBehaviour
{
    [SerializeField] Transform[] _targets;
    [SerializeField] float _speed = 3f;
    [SerializeField] float _stopDis = 0.05f;
    int _targetIndex = 0;
    [SerializeField] Vector3 dir;
    GameObject _warpMazzle;
    [SerializeField] bool _change;
    bool _changeTime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!_change)
        {
            Patrol();
            Flip(dir.x);
        }
        else
        {
            if (!_changeTime)
            {
                StartCoroutine(ChangeTime());
                _changeTime = true;
            }
        }
    }
    IEnumerator ChangeTime()
    {
        yield return new WaitForSeconds(3f);
        transform.localScale = new Vector3(transform.localScale.x, -1 * transform.localScale.y, transform.localScale.z);
        _changeTime = false;
    }

    void Patrol()
    {
        float distance = Vector2.Distance(transform.position, _targets[_targetIndex].position);

        if (distance > _stopDis)
        {
            dir = (_targets[_targetIndex].transform.position - transform.position).normalized * _speed;
            transform.Translate(dir * Time.deltaTime);
        }
        else
        {
            _targetIndex++;
            _targetIndex = _targetIndex % _targets.Length;
        }
    }

    void Flip(float y)
    {
        if (y < -1)
        {
            transform.localScale = new Vector3(transform.localScale.x , -1 * Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
        else if (y > 1)
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
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
