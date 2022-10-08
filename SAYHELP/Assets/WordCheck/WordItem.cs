namespace InfoSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.Events;
    using TMPro;
    using System;
    using UnityEngine.UI;
    using DG.Tweening;
    public class WordItem : MonoBehaviour,IWord
    {
        //private Text txt; //individrual letter
        private Text txt; //individrual letter
        public string info; // string of the letter
        [SerializeField]
        private bool isCheck = false; //have been seened or not
        public int index; // place of the letter or space in this line

        public ShowInfoType lineIndex;

        public Action  enterAct;
        public Action exitAct;


        void Start()
        {
            txt = GetComponent<Text>(); // get the TMP component
           
            //txt.textInfo.textComponent.text = info; // get the content of the text
                                                    // gameObject.AddComponent<BoxCollider>();
            txt.text=info; // get the content of the text                                      
            txt.color = Color.clear;
          //  txt.rectTransform.localScale = Vector2.zero;

        }
        //When the mouse enters the text mesh
        public void EnterCheck()
        {
            //
            if(!WordInfoSystem.Single.canScan){
                return;
            }
            if (isCheck)
            {
                WordInfoSystem.Single.debugtXT.text = WordInfoSystem.Single.recordEndSuccess ? "finished reading this line" : "this letter detected";
                return;
            }
            ChageColor(Color.green);
            // if (WordInfoSystem.Single.Count == index && !isCheck)
            // {
            //     isCheck = true;
            //     ChageColor(Color.green);
            //     WordInfoSystem.Single.RecordAddWord(this);
            //     WordInfoSystem.Single.debugtXT.color = Color.yellow;
            //     WordInfoSystem.Single.debugtXT.text = "read, index" + WordInfoSystem.Single.Count;
            //     WordInfoSystem.Single.Count++;
            // }
            // else
            // {
            //     ChageColor(Color.red);
            //     WordInfoSystem.Single.debugtXT.color = Color.red;
            //     WordInfoSystem.Single.debugtXT.text = "Please read everything carefully";
            // }
        }

        public void ExitCheck()
        {
            if (isCheck||!WordInfoSystem.Single.canScan)
            {
                return;
            }
            ChageColor(Color.white);
        }

        private void OnMouseEnter()
        {
            if(enterAct!=null)
            {
                print("Enter!!!!");
                enterAct();
            }
           // EnterCheck();
        }

        private void OnMouseExit()
        {
           // EnterCheck();
           if (exitAct!=null)
           {
                exitAct();
           }
        }

        public void PlayAni()
        {
            txt.DOColor(Color.white, 0.01f);
            //txt.rectTransform.DOScale(Vector3.one, 0.3f);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
          //  EnterCheck();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
           // ExitCheck();
        }
        public void ChageColor(Color enterColor)
        {
            txt.color = enterColor;
        }

    }
}