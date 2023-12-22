using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ƒQ[ƒ€–{•Ò‚ğŠÇ—‚·‚é
/// </summary>
public class PlaySceneManager : MonoBehaviour
{
    /// <summary>Œ®‚ÌÅ‘å”</summary>
    [SerializeField] int _maxKeyCount;
    /// <summary>Œ»İ‚ÌŒ®‚ÌŒÂ”</summary>
    int CurrentKeyCount { get; set; }
    public int _countCey => CurrentKeyCount;


void Awake()
    {
        CurrentKeyCount = 0;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void CeyCount()
    {
        CurrentKeyCount++;
    }
}
