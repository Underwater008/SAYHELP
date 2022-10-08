namespace InfoSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    public class WordGroup : MonoBehaviour
    {
        public List<WordItem> allWordItemList;
        public int compareValue;

        void Start()
        {
            allWordItemList=transform.GetComponentsInChildren<WordItem>().ToList(); 

            foreach (var item in allWordItemList)
            {
                item.compareValue = compareValue;
            }         
        }
        
        public void  SetAllSoonEnterState()
        {
            foreach (var item in allWordItemList)
            {
                item.EnterCheck();
            } 
          
            Debug.LogWarning("Enter ");
        }

         public void  SetAllSoonExitState()
        {
            foreach (var item in allWordItemList)
            {
                item.ExitCheck();
            }  
             Debug.LogWarning("Exit ");
        }
    }
}