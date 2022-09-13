using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void ButtonExit()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }
}
