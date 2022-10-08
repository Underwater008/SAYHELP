namespace InfoSystem
{
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.EventSystems;
using UnityEngine.Events;

/// <summary>
/// see here https://lightbuzz.com/speech-recognition-unity/
/// </summary>
public class TextSpeechRecognitionEngine : MonoBehaviour
{
    public string[] keywords = new string[] { "help", "play", "delete", "I", "am", "Bella", "Max", "get", "closer", "What", "a", "jackass","nice", "God", "be", "with", "you", "All", "going", "to", "visit", "Lucy", "because", "mister", "Honey" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;

    public Text results;

    protected PhraseRecognizer recognizer;
    protected string word;
    public static TextSpeechRecognitionEngine Single;

    //Start the listener
    public void StartRecongnizer(){
            Debug.Log("Start Recongnizer");
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            Debug.Log( recognizer.IsRunning );
    }
    
    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            Debug.Log( recognizer.IsRunning );
        }

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }

    private void Update()
    {

        /*switch (word)
        {
            case "help":

                break;
        }*/
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}}
