using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Event0302 : MonoBehaviour
{
    public GameObject ch0302image;
    public GameObject ch0302text;
    float nowtime = 0.0f;
    float nowtime2 = 0.0f;
    bool isfade = false;
    bool speechstart = false;
    bool imagefadeoutdone = false;

    // Start is called before the first frame update
    void Start()
    {
        ch0302text.SetActive(false);
        ch0302image.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        fadein();
        speech();
        textfadein();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            ch0302image.SetActive(true); // ������ �̹��� Ű��
            isfade = true;
            speechstart = true;
            GetComponent<BoxCollider>().enabled = false; //�ٽ� �ݶ��̴��� �ε����� �� ����Ǵ� ���� �����ϱ� ���� �ݶ��̴� ����
        }
    }

    void fadein()
    {
        if(isfade)
        {
            nowtime += Time.deltaTime;
            ch0302image.GetComponent<Image>().color = new Color(0, 0, 0, nowtime / 2);


            if (nowtime > 5)
            {
                imagefadeoutdone = true;
                ch0302text.SetActive(true); // ���̵��� �������� �ؽ�Ʈ Ű��
                isfade = false; //���̵��� �������� ���̻� �ڵ尡 ����� �ʿ� �����Ƿ� isfade ���� false �ֱ�
            }

        }
    }

    void speech()
    {
        if (speechstart)
        {
            PlayerSpeechScreen.Instance.stopspeech();
            PlayerSpeechScreen.Instance.startspeech("���� �����̾� ���⼭ ���� �� �־�!", "", "", "", "");
            speechstart = false;
        }
            
    }

    void textfadein()
    {
        if (imagefadeoutdone)
        {
            nowtime2 += Time.deltaTime;
            ch0302text.GetComponent<Text>().color = new Color(255, 255, 255, nowtime2 / 2);

            if (nowtime2>8)
                SceneManager.LoadScene("Chapter3NormalClear");

        }
    }
}
