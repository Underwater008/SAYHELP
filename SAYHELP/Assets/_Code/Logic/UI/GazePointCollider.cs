using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfoSystem;

public class GazePointCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
                    Debug.Log("GameObject1 collided with <" + col.name + "> Enter");
        if(col.CompareTag("word"))
        {

            col.GetComponent<WordItem>().WG.SetAllSoonEnterState();

        }
    }
        
        void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("word"))
        {
            Debug.Log("GameObject1 collided with <" + other.name + "> Exit");
            other.GetComponent<WordItem>().WG.SetAllSoonEnterState();            
        }
    }
}
