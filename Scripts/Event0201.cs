using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Event0201 : MonoBehaviour
{
    public GameObject DiaryBody;
    public GameObject ifkey;
    public GameObject Zombie2;

    public GameObject[] position123 = new GameObject[3];

    bool canplay = true;
    int patrol = 1;
    float nowtime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Zombie2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("PlayerInventory").GetComponent<PlayerInventory>().findinven(ifkey.name) && canplay) //ifkey�� �̸��� �κ��丮�� �����ϰ� canplay�� ��
        {

            Zombie2.SetActive(true); //Ȱ��ȭ
            DiaryBody.GetComponent<Text>().text = "������ ���� â��� �̵�����.\nLeftCtrlŰ�� ���� ������ ������ �þ߿��� ������ �ʰ� �Ǵ� �� ����.";
            PlayerSpeechScreen.Instance.stopspeech();
            PlayerSpeechScreen.Instance.startspeech("ȭ��� �ʿ��� ���� �Ҹ��� ��ȴµ�","","","","");
            canplay = false; //�ٽ� �ߵ� ���ϰ� false
        }



                nowtime += Time.deltaTime;
                if (nowtime > 10 && Zombie2.activeSelf) {
                        patrol = Random.Range(0, 3); //10�ʸ��� patrol 1~3 ����
                        Zombie2.GetComponent<NavMeshAgent>().destination=position123[patrol].transform.position; //�������� �迭 �ε�����
                        nowtime = 0.0f; //���� ������ ���� �ð��ʱ�ȭ
                }
                if(Zombie2.activeSelf)
                Zombie2.GetComponent<Animator>().SetFloat("Speed", Zombie2.GetComponent<NavMeshAgent>().velocity.magnitude);
    }
}