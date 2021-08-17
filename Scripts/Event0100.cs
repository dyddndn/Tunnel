using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event0100 : MonoBehaviour
{
    public GameObject Body;
    public GameObject StartFadeInOutImage;
    public GameObject StartFadeText;
    public float nowtime = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartFadeInOutImage.SetActive(true);
        StartFadeText.SetActive(true);

        Body.GetComponent<Text>().text = "������ ���� �����ͳο� �������� �Ǿ���. �� ���� �����غ���.";
        PlayerPrefs.SetInt("chap", 1);
        PlayerSpeechScreen.Instance.startspeech("����...", "���� �����? �и� ������ ���� ���̾��µ�", "���� �������� ����� ã�ƺ��߰ھ�", "", "");
    }

    // Update is called once per frame
    void Update()
    {
        if (nowtime < 5.0f) //5�ʵ��� �ð������� ����(���İ��� 0�Ͻ� �Ⱥ���)
        {
            nowtime += Time.deltaTime;
            StartFadeInOutImage.GetComponent<Image>().color = new Color(0, 0, 0, 5 - nowtime);
            StartFadeText.GetComponent<Text>().color = new Color(255, 255, 255, 5 - nowtime);
        }
        
    }
}
