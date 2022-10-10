using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraStencilMask1Trigger : MonoBehaviour
{
    public GameObject cameraMask;

    public bool maskActive = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide");
        if (other.CompareTag("MainCamera") && !maskActive)
        {
            maskActive = true;
            cameraMask.SetActive(true);
        }

        //if (other.CompareTag("MainCamera") && maskActive)
        //{
        //    maskActive = false;
        //    cameraMask.SetActive(false);
        //}

    }
}
