using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerspeech : MonoBehaviour
{
    Text speech;
    string[] txts = new string[5];

    public IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        speech = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void change(int count)
    {
        speech.text = txts[count];
    }

    IEnumerator changespeechtext(string txt, string txt2, string txt3, string txt4, string txt5)
    {

        speech.text = txt;
        yield return new WaitForSeconds(4.0f);
        speech.text = txt2;
        yield return new WaitForSeconds(4.0f);
        speech.text = txt3;
        yield return new WaitForSeconds(4.0f);
        speech.text = txt4;
        yield return new WaitForSeconds(4.0f);
        speech.text = txt5;
    }

    public void setspeechtext(string txt, string txt2, string txt3, string txt4, string txt5)
    {
        StartCoroutine(changespeechtext(txt, txt2, txt3, txt4, txt5)); //대사 시작
    }
}
