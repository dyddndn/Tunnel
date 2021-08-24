using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;

public class PlayerSpeechScreen : MonoBehaviour
{

    public static PlayerSpeechScreen Instance;

    IEnumerator speechCoroutine;
    public GameObject PlayerSpeech;
    Text speech;
    string[] txts = new string[5];

    // Start is called before the first frame update

    void Awake()
    {
        Instance = this;

        speech = PlayerSpeech.GetComponent<Text>();
        speech.text = "";

        for (int i = 0; i < 5; i++)
        {
            txts[i] = ""; //ó���� ���ڿ� ����
        }


        PlayerSpeechScreen.Instance.speechCoroutine = StartspeechCoroutine(); //���ڿ��� ����ִ� �ڷ�ƾ�� �غ�
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public void stopspeech()
    {
        StopCoroutine(speechCoroutine); //�ڷ�ƾ �������� �ʰ� ������ִ� �ڷ�ƾ ��ž
        Debug.Log("�ڷ�ƾ����");
    }

    public void startspeech(string txt1, string txt2, string txt3, string txt4, string txt5)
    {

        //���Ŀ� �Ʒ� �밡�� �ڵ带 1.������ ��Ʈ�� ���ڰ��� ���ٷ� �ؼ� ��ǥ�� ���� �� ���� 2. �迭�� �޾Ƽ� ���� ���� ����
        txts[0] = txt1;
        txts[1] = txt2;
        txts[2] = txt3;
        txts[3] = txt4;
        txts[4] = txt5;

        speechCoroutine = StartspeechCoroutine(); //���ڿ� ���� �ڷ�ƾ�� �غ�
        StartCoroutine(speechCoroutine);
        Debug.Log("�ڷ�ƾ����");

    }

    public IEnumerator StartspeechCoroutine()
    {
        for(int i=0; i < 5; i++)
        {
        speech.text = txts[i];
        yield return new WaitForSeconds(4.0f);
        }
        speech.text = ""; //������ ����
    }
}
