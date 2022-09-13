using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    [SerializeField] string _sceneName;

    public void LoadNextScene(string sceneName)
    {
        Debug.Log($"UIが押されたに{_sceneName}移行");
        SceneManager.LoadScene(_sceneName);
    }
}
