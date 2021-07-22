using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderEvent1 : MonoBehaviour
{
    public GameObject zombie;
    public GameObject characterspeech;
    Text speech;

    bool canplay = true;
    // Start is called before the first frame update
    void Start()
    {
        zombie.SetActive(true);
        speech = characterspeech.GetComponent<Text>();
        speech.text = "";
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
            characterspeech.GetComponent<Playerspeech>().setspeechtext("방금 뭐였지?","어서 따라가보자","","","");
            canplay = false; //한번 대사했으면 다시 X

        }

        
    }
}
