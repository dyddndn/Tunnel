using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event0101 : MonoBehaviour
{
    public GameObject DiaryBody;
    public GameObject zombie;
    Text speech;

    bool canplay = true;
    // Start is called before the first frame update
    void Start()
    {
        zombie.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canplay) //닿은 물체의 태그가 Player고 canplay가 true 상태면
        {
            zombie.SetActive(false);
            PlayerSpeechScreen.Instance.stopspeech();
            PlayerSpeechScreen.Instance.startspeech("방금 누군가가 보였는데...", "", "", "", "");
            DiaryBody.GetComponent<Text>().text = "철창 뒤로 누군가의 모습이 보였다. 열쇠를 찾아 문을 열고 나가보자.";
            canplay = false; //한번 대사했으면 다시 X

        }

        
    }
}
