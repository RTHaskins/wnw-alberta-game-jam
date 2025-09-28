using UnityEngine;
using UnityEngine.UI;

public class VoskResultText : MonoBehaviour 
{
    public VoskSpeechToText VoskSpeechToText;
    public TMPro.TextMeshPro ResultText;

    void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    private void OnTranscriptionResult(string obj)
    {
        Debug.Log(obj);
        var result = new RecognitionResult(obj);
        ResultText.text = "";
        if (result.Phrases[0].Text == "[unk]") {
            ResultText.text = "";
        }
        else
        {
            ResultText.text = result.Phrases[0].Text;
        }
    	
    }
}
