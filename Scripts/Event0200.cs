using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event0200 : MonoBehaviour
{
    public GameObject DiaryBody;
    public GameObject StartFadeInOutImage;
    public GameObject StartFadeText;
    public float nowtime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartFadeInOutImage.SetActive(true);
        StartFadeText.SetActive(true);
        PlayerSpeechScreen.Instance.stopspeech();
        PlayerSpeechScreen.Instance.startspeech("���� ���� ����?", "���� �� �ִ� ����� ã�ƺ��߰ھ�","","",""); //���� �� �÷��̾� ȥ�㸻
        DiaryBody.GetComponent<Text>().text = "������� �� ���忡 �������ȴ�.\n���� �� �ִ� ����� ã�ƺ���."; //���� �� ���� ������Ʈ

        PlayerPrefs.SetInt("chap", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (nowtime < 5.0f)
        {
            nowtime += Time.deltaTime;
            StartFadeInOutImage.GetComponent<Image>().color = new Color(0, 0, 0, 5 - nowtime);
            StartFadeText.GetComponent<Text>().color = new Color(255, 255, 255, 5 - nowtime);

        }

        if (nowtime > 5.0f)
        {
            StartFadeInOutImage.SetActive(false);
            StartFadeText.SetActive(false);
        }
    }

}
