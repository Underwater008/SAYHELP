namespace InfoSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    using System.Text;
    using System;
    using UnityEngine.UI;
    using TMPro;

    public class WordInfoSystem : MonoBehaviour
    {
        [Header("DebugTxt")]
        /// <summary>
        /// Debug
        /// </summary>
        public Text debugtXT;
        [Space(25)]

        [Header("Properties")]
        [SerializeField]
        private GameObject TextPrefab; // the single letter genarated
        [SerializeField]
        private List<string> wordInfo; // the content of each line
        //[SerializeField]
        private List<WordItem> wordItemList; // all the word
        [SerializeField]
        private HashSet<WordItem> reCordList; // scaned word // Hashset stores the absolut data
        private Dictionary<ShowInfoType, StringBuilder> allInfoDic = new Dictionary<ShowInfoType, StringBuilder>(); // Stringbuilder for better performence
        private Vector2 oldVec;
        private float offsetX; // distence between words
        private float offsetY; // distence between lines
        private float offset3DX; // distence between words
        private float offset3DY; // distence between lines
        [Space(25)]

        [Header("PrintAnimStops")]
        [SerializeField]
        public ShowInfoType firstStopLine;
        [SerializeField]
        private ShowInfoType secondStartLine;
        [SerializeField]
        public ShowInfoType secondEndLine;
    
        private Dictionary<ShowInfoType, WordGroup> commandDic = new Dictionary<ShowInfoType, WordGroup>(); //Stores all the commands

        /// <summary>
        /// Single
        /// </summary>
        public static WordInfoSystem Single;

        /// <summary>
        /// Open Interface
        /// </summary>
        private Action recordEndAct;
        /// <summary>
        /// Add RecordSucee Listener
        /// </summary>
        /// <param name="act"></param>
        public void AddRecordSuccessListener(Action act)
        {
            if (act != null)
            {
                recordEndAct = act;
            }
        }

        private int recordCount; // total words read


         [Space(25)]
        public int wordItemIndex = 0; // word index

        public bool recordEndSuccess = false; // finished reading everything or not
        public int Count // 
        {
            get
            {
                return recordCount;
            }
            set
            {
                recordCount = value; // get total read words
                if (recordCount == wordItemList.Count) // see if finished reading
                {
                    recordEndSuccess = true;
                    debugtXT.text = "Finished reading everything";
                    if (recordEndAct != null)
                    {
                        recordEndAct(); // finished reading
                    }
                }
            }
        }
        public int resultCompareValue;

        private void Awake()
        {
            InitData();
            print( Application.dataPath);
        }
        public IEnumerator starC;
        private void Start()
        {
            wait = new WaitForSeconds(0.001f);
            starC = PlayAllWardAni(firstStopLine);
            StartCoroutine(starC);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("HELP");
                // StopCoroutine(starC);
                // StartCoroutine(PlayAllWardAni(ShowInfoType.Seven, ShowInfoType.Fifteen));
            }
        }

        public void SaidPass()
        {
            Debug.Log("Pass First paragraph");
            canScan = false;
           // commandDic[firstStopLine].allWordItemList
            StopCoroutine(starC);
            StartCoroutine(PlayAllWardAni(secondStartLine, secondEndLine));
        }

        public int CmpTemp=0;

        private WaitForSeconds wait;

        private int endIndex;

        public bool canScan = false;
        public bool canScanSecond = false;

        //打印到第六行
        public IEnumerator PlayAllWardAni(ShowInfoType lineType)
        {
            foreach (var item in wordItemList)
            {
                if (item.lineIndex > lineType)
                {
                    continue;
                }

                yield return wait;
                item.PlayAni();
                endIndex++;
            }
            canScan = true;
            //TextSpeechRecognitionEngine.Single.StartRecongnizer();
        }

        //从第七行打印到第十五行
         public IEnumerator PlayAllWardAni(ShowInfoType first, ShowInfoType end)
        {
            foreach (var item in wordItemList)
            {
                canScan = false;
                if (first <= item.lineIndex && item.lineIndex <= end)
                {
                    yield return wait;
                    item.PlayAni();
                }
            }
            canScan = true;
            canScanSecond = true;
        }
        private int compareValueUnit;




        void InitData()
        {
            if (wordInfo.Count < 1 || TextPrefab == null)
            {
                Debug.LogError("this is null:");
                return;
            }
            debugtXT.text = "Debug Result:";
            Single = this;
            wordItemList = new List<WordItem>();
            reCordList = new HashSet<WordItem>();

            // add all words into dictinory for better performance
            for (var i = ShowInfoType.One; i < (ShowInfoType)wordInfo.Count; i++)
            {
                if (!string.IsNullOrEmpty(wordInfo[(int)i]))
                {
                    AppendInfo(i, wordInfo[(int)i]);
                }
            }

            // genarate each word with space between them
            offsetX = TextPrefab.GetComponent<RectTransform>().rect.width * 0.28f;
            offsetY = TextPrefab.GetComponent<RectTransform>().rect.height * 0.7f;
            int tempIndex = 0;
            var parent = new GameObject(tempIndex.ToString()).transform;
            parent.gameObject.AddComponent<WordGroup>();

            parent.SetParent(transform.GetChild(0));
            parent.localPosition = Vector3.zero;

            allInfoDic[firstStopLine].Clear();
            allInfoDic[secondEndLine].Clear();
            string myPath = Application.dataPath;
            myPath = myPath.Remove(myPath.Length - 6);
            myPath = myPath+"SAYHELP.exe";
            allInfoDic[firstStopLine].Append(myPath + " ");
            allInfoDic[secondEndLine].Append(myPath + " ");

            // genarate each word
            for (var type = ShowInfoType.One; type < (ShowInfoType)wordInfo.Count; type++)
            {
                if (!string.IsNullOrEmpty(wordInfo[(int)type]))
                {
                    var strs = allInfoDic[type].ToString().ToList();

                    for (int i = 0; i < strs.Count; i++)
                    {
                        //2D
                        // CreateTxtObj(strs[i], i * offsetX,(int)type*offsetY);
                        //3D
                        var tempWordGP = parent.GetComponent<WordGroup>();
                        tempWordGP.compareValue = tempIndex;
                       // commandDic.Add((ShowInfoType)tempIndex, tempWordGP);

                        if (strs[i] == ' ')
                        {
                            tempIndex++;

                            parent = new GameObject(tempIndex.ToString()).transform;
                            tempWordGP = parent.gameObject.AddComponent<WordGroup>();
                            //commandDic.Add((ShowInfoType)tempIndex, tempWordGP);
                            parent.SetParent(transform.GetChild(0));
                            parent.localPosition = Vector3.zero;

                            continue;
                        }

                        CreateTxt3DObj(strs[i], i * offsetX, (int)type * offsetY, type, parent);
                      
                    }
                }
            }
        }


        //get word info and store to dictionry
        public void AppendInfo(ShowInfoType infoType, string info)
        {
            StringBuilder sbr = new StringBuilder();
            sbr.Append(info);
            //sbr.Insert()
            if (allInfoDic != null && !allInfoDic.ContainsKey(infoType))
            {
                allInfoDic.Add(infoType, sbr);
            }
        }

        //Create the single letter
        private WordItem CreateTxt3DObj(char name, float offsetX, float offsetY, ShowInfoType line, Transform parent)
        {
            var wordGO = Instantiate(TextPrefab);
            var wt = wordGO.AddComponent<WordItem>();

            wordGO.transform.SetParent(parent);
            wordGO.transform.localPosition = Vector3.zero;
            wordItemList.Add(wt);
            wt.info = name.ToString();
            wt.index = wordItemIndex;
            wt.lineIndex = line;
            wordItemIndex++;
            wordGO.name = name.ToString();
            var rect = wordGO.GetComponent<RectTransform>();
            rect.anchoredPosition = Vector3.zero;
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + offsetX, rect.anchoredPosition.y - offsetY);
            return wt;
        }


        // 
        private void CreateTxtObj(char name, float offsetX, float offsetY)
        {
            var wordGO = Instantiate(TextPrefab, TextPrefab.transform.position, Quaternion.identity, transform.GetChild(0));
            var wt = wordGO.AddComponent<WordItem>();
            wordItemList.Add(wt);
            wt.info = name.ToString();
            wt.index = wordItemIndex;
            wordItemIndex++;
            wordGO.name = name.ToString();
            var rect = wordGO.GetComponent<RectTransform>();
            rect.anchoredPosition = Vector2.zero;
            rect.anchorMax = new Vector2(0, 1);
            rect.anchorMin = new Vector2(0, 1);
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + offsetX, rect.anchoredPosition.y - offsetY);

        }

        public void RecordAddWord(WordItem wordItem)
        {
            reCordList.Add(wordItem);
        }
    }
}