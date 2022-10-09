using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;
 using InfoSystem;
public class WordGazeAware : MonoBehaviour
{
    private GazeAware _gazeAware;
    private WordItem wordIten;
 
    void Start()
    {
        _gazeAware = GetComponent<GazeAware>();
        wordIten= GetComponent<WordItem>();
    }
 
    void Update()
    {
        // if (_gazeAware.HasGazeFocus)
        // {
        //     wordIten.WG.SetAllSoonEnterState();
        // }
        // else
        // wordIten.WG.SetAllSoonExitState();
    }
}
