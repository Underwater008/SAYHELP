using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;
 
public class WordGazeAware : MonoBehaviour
{
    private GazeAware _gazeAware;
 
    void Start()
    {
        _gazeAware = GetComponent<GazeAware>();
    }
 
    void Update()
    {
        if (_gazeAware.HasGazeFocus)
        {
            transform.Rotate(Vector3.forward);
        }
    }
}
