using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeScript : MonoBehaviour
{
    PlaySceneManager Playscene;
    [SerializeField] string _sceneName;
    [SerializeField] GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Playscene = GameObject.FindGameObjectWithTag("GM").GetComponent<PlaySceneManager>();
            if(Playscene._countCey == 5)
            {
                SceneManager.LoadScene(_sceneName);
            }
            else
            {
                text.SetActive(true);
                StartCoroutine(textTime());
            }
        }
    }
    IEnumerator textTime()
    {
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
