using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]float _coolTime = 3.5f;
    bool _cool;
    [SerializeField] GameObject _enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_cool)
        {
            StartCoroutine(SpawnTime());
            _cool = true;
        }
    }
    IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(_coolTime);
        Instantiate(_enemy, transform.position, Quaternion.identity);
        _cool = false;
    }

}
