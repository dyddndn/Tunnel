using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event0202 : MonoBehaviour
{
    public GameObject Entrancekey;
    bool Eventdid = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Entrancekey.activeSelf && !Eventdid)
        {
            PlayerSpeechScreen.Instance.stopspeech();
            PlayerSpeechScreen.Instance.startspeech("���� �̰��� �������� �� �־�", "������ �Ǹ� �ڵ� ���ƺ����ʰ� �޷��� ��", "", "", ""); //���� �� �÷��̾� ȥ�㸻
            Eventdid = true;
        }
    }
}
