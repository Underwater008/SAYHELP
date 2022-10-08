namespace InfoSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    public class WordGroup : MonoBehaviour
    {
        public List<WordItem> allSonnWordItems;
        void Start()
        {
            allSonnWordItems =GetComponentsInChildren<WordItem>().ToList();
          
        }
        void Update(){

           if ( Input.GetKeyDown(KeyCode.Space))
           {
               foreach (var item in allSonnWordItems)
            {
              item.EnterCheck();
              Debug.LogWarning("Enter!!!!");
            }
           }
            
        }

        
        private void AddRegister()
        {
            foreach (var item in allSonnWordItems)
            {
                item.enterAct=()=>EmterRegister();
                item.exitAct=()=>ExitRegister();
            }
        }

        private void EmterRegister()
        {
            foreach (var item in allSonnWordItems)
            {
                item.EnterCheck();
            }
        }

        private void ExitRegister()
        {
            foreach (var item in allSonnWordItems)
            {
                item.ExitCheck();
            }
        }
    }
}