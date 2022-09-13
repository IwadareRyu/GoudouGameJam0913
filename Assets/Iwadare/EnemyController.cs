using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform[] _targets;
    [SerializeField] float _speed = 3f;
    [SerializeField] float _stopDis = 0.05f;
    int _targetIndex = 0;
    [SerializeField] Vector3 dir;
    [SerializeField] GameObject _lengeX;
    [SerializeField] GameObject _lengeY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        Flip(dir.x , dir.y);
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

    void Flip(float x,float y)
    {
        if(x < -1)
        {
            _lengeY.SetActive(false);
            _lengeX.SetActive(true);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        else if(x > 1)
        {
            _lengeY.SetActive(false);
            _lengeX.SetActive(true);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if(y < -1)
        {
            _lengeY.SetActive(true);
            _lengeX.SetActive(false);
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y) * -1, transform.localScale.z);
        }
        else if (y > 1)
        {
            _lengeY.SetActive(true);
            _lengeX.SetActive(false);
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
    }
}
