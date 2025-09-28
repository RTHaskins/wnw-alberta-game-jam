using UnityEngine;
using UnityEngine.UI;

public class VoskResultText : MonoBehaviour 
{
    public VoskSpeechToText VoskSpeechToText;
    public Text ResultText;

    void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    private void OnTranscriptionResult(string obj)
    {
        Debug.Log(obj);
        var result = new RecognitionResult(obj);
        if (result.Phrases[0].Text == "[unk]")
        {
            ResultText.text = "Use a Valid Command [Hiss, Chirp, Meow]";
        }
        else
        {
            ResultText.text = result.Phrases[0].Text.ToUpper();
        }
    }
}
