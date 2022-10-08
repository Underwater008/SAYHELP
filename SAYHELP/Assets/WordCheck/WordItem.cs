namespace InfoSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.Events;
    using TMPro;
    using UnityEngine.UI;
    using DG.Tweening;
    using System;
    public class WordItem : MonoBehaviour,IWord
    {
        //private Text txt; //individrual letter
        private Text txt; //individrual letter
        public string info; // string of the letter
        [SerializeField]
        private bool isCheck = false; //have been seened or not
        public int index; // place of the letter or space in this line

        public ShowInfoType lineIndex;
        private WordGroup wg;

        public WordGroup WG
        {
            get
            {
                if (wg==null)
                {
                    wg=transform.parent.GetComponent<WordGroup>();
                }
                return  wg;
            }
        }
      

        void Start()
        {
            txt = GetComponent<Text>(); // get the TMP component
           
            //txt.textInfo.textComponent.text = info; // get the content of the text
                                                    // gameObject.AddComponent<BoxCollider>();
            txt.text=info; // get the content of the text                                      
            txt.color = Color.clear;
          //  txt.rectTransform.localScale = Vector2.zero;

        }

        public int compareValue;
        //When the mouse enters the text mesh
        public void EnterCheck()
        {
            if(!WordInfoSystem.Single.canScan){
                return;
            }

            if (isCheck)
            {
                WordInfoSystem.Single.debugtXT.text = WordInfoSystem.Single.recordEndSuccess ? "finished reading this line" : "this letter detected";
                return;
            }
            Debug.LogWarning("0111111111111111111111111");
            if (compareValue==WordInfoSystem.Single.resultCompareValue&& !isCheck)
            {
                isCheck = true;   
                ChageColor(Color.green);
                WordInfoSystem.Single.RecordAddWord(this);
                WordInfoSystem.Single.debugtXT.color = Color.yellow;
                WordInfoSystem.Single.debugtXT.text = "read, index" + WordInfoSystem.Single.Count;
                WordInfoSystem.Single.Count++;
                WordInfoSystem.Single.CmpTemp++;
                if(WG.allWordItemList.Count==WordInfoSystem.Single.CmpTemp)
                {
                    WordInfoSystem.Single.resultCompareValue++;
                    WordInfoSystem.Single.CmpTemp=0;
                }
            }
            else
            {
                ChageColor(Color.red);
                WordInfoSystem.Single.debugtXT.color = Color.red;
                WordInfoSystem.Single.debugtXT.text = "Please read everything carefully";
            }
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
          //  EnterCheck();
          //print(111);
         // WG.SetAllSoonEnterState();
        }

        private void OnMouseExit()
        {
           // ExitCheck();
          // print(222)
;          // WG.SetAllSoonExitState();
        }

        //show the letter
        public void PlayAni()
        {
            txt.DOColor(Color.white, 0.01f);
            //txt.rectTransform.DOScale(Vector3.one, 0.3f);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            //EnterCheck();
            // print(333);
             WG.SetAllSoonEnterState();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
           // ExitCheck();
          // print(444);
           WG.SetAllSoonExitState();
        }
        public void ChageColor(Color enterColor)
        {
            txt.color = enterColor;
        }

    }
}