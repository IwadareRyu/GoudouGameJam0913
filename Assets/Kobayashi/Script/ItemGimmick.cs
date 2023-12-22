using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemGimmick : MonoBehaviour
{
    [SerializeField]UnityEvent _action;
    [SerializeField] GameObject _keyAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _action.Invoke();
            Instantiate(_keyAudio, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
