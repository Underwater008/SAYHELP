using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

    public Camera lowResCam;

 Ray ray;
     RaycastHit hit;
     
     void Update()
     {
         ray = lowResCam.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             print (hit.collider.name);
         }
     }
}
