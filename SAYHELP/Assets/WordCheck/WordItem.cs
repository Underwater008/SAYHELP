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

        private WordInfoSystem wordInfoMgr;

        public WordInfoSystem WordInfoSystemMgr
        {
            get
            {
                if (wordInfoMgr==null)
                {
                    wordInfoMgr = WordInfoSystem.Single;
                }
                return wordInfoMgr;
            }
        }

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
            if(!WordInfoSystemMgr.canScan){
                return;
            }

            if(this.lineIndex > WordInfoSystemMgr.firstStopLine && !WordInfoSystemMgr.canScanSecond)
            {
                return;
            }

            if (isCheck)
            {
                WordInfoSystemMgr.debugtXT.text = WordInfoSystemMgr.recordEndSuccess ? "finished reading this line" : "this letter detected";
                return;
            }
            if (compareValue==WordInfoSystemMgr.resultCompareValue&& !isCheck)
            {

                isCheck = true;   
                ChageColor(Color.green);
                WordInfoSystemMgr.RecordAddWord(this);
                WordInfoSystemMgr.debugtXT.color = Color.yellow;
                WordInfoSystemMgr.debugtXT.text = "read, index" + WordInfoSystemMgr.Count;
                WordInfoSystemMgr.Count++;
                WordInfoSystemMgr.CmpTemp++;
                if(WG.allWordItemList.Count==WordInfoSystemMgr.CmpTemp)
                {
                    WordInfoSystemMgr.resultCompareValue++;
                    WordInfoSystemMgr.CmpTemp=0;
                }
            }
            else
            {
                //ChageColor(Color.red);
                WordInfoSystemMgr.debugtXT.color = Color.red;
                WordInfoSystemMgr.debugtXT.text = "Please read everything carefully";
            }
        }

        public void ExitCheck()
        {
            if (isCheck||!WordInfoSystemMgr.canScan)
            {
                return;
            }
            //ChageColor(Color.white);
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
            txt.DOColor(Color.white, 0f);
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