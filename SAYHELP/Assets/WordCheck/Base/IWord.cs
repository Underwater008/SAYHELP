namespace InfoSystem
{
    using UnityEngine.EventSystems;
    using UnityEngine;
    public interface IWord : IPointerEnterHandler /* when the cursor hit the text mesh*/, IPointerExitHandler // when the cursor leaves the text mesh 
    {
        void ChageColor(Color enterColor); // change the color of individrual letter
        
    }


    public enum ShowInfoType // determine which line are the text on
    {
        One, // line 1
        Two, // line 2
        Three, //line 3
        Four, //line 4
        Five, //line 5
        Six, //line 6
        Seven, //line 7
        Eight, //line 8
        Nine, //line 9
        Ten, //line 10
        Eleven, //line 11
        Twelve, //line 12
        Thirteen, //line 13
        Fourteen, //line 14
        Fifteen, //line 15
        Sixteen, //line 16
        
        COUNT // length of the lines //Flag bit of traversal enumeration
    }
}