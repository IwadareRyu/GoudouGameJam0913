using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    [SerializeField] string _sceneName;

    public void LoadNextScene(string sceneName)
    {
        Debug.Log($"UI‚ª‰Ÿ‚³‚ê‚½‚É{_sceneName}ˆÚs");
        SceneManager.LoadScene(_sceneName);
    }
}
