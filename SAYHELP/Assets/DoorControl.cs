namespace InfoSystem
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


    public class DoorControl : MonoBehaviour
{
        private  GameObject Door;

        //door plate
        public GameObject doorPlate;

        public Camera lowResCam;



        public static DoorControl Single;

        // Start is called before the first frame update
        private void Awake()
        {
            Door = gameObject;
            Single = this;
            Door.transform.position = new Vector3(0f, -0.4f, 0f);
            gameObject.SetActive(false);
        }

        public void ActivateDoor()
        {
            Door.SetActive(true);
            //Move the door closer
            Door.transform.DOMoveZ(-64.0f, 5.0f);
        }

        public void OpenDoor()
        {
            doorPlate.transform.DOLocalRotate(new Vector3(0f, 120f, 0f), 1f);
        }

        public void GoInsideDoor()
        {
            Door.transform.DOMoveZ(-69.5f, 2.5f);
        }

        public void TurnAround()
        {
            lowResCam.transform.DORotate(new Vector3(0f, 160f, 0f), 1f);
            doorPlate.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 2.5f);
        }
}
}
