using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] string _sceneName;

    public void MoveTitle()
    {
        Debug.Log("ƒV[ƒ“„ˆÚ");
        SceneManager.LoadScene(_sceneName);
    }
}
