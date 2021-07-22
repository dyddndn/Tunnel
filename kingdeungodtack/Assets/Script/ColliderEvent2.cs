using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ColliderEvent2 : MonoBehaviour
{
    public GameObject zombie;
    public GameObject characterspeech;
    public GameObject target;

    Animator anim;
    Text speech;

    bool canplay = true;
    // Start is called before the first frame update
    void Start()
    {
        zombie.SetActive(false);
        anim = zombie.GetComponent<Animator>();
        speech = characterspeech.GetComponent<Text>();
        speech.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        zombie.GetComponent<NavMeshAgent>().destination = target.transform.position;
        anim.SetFloat("Speed", zombie.GetComponent<NavMeshAgent>().velocity.magnitude);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canplay) //닿은 물체의 태그가 Player고 canplay가 true 상태면
        {
            zombie.SetActive(true);
            characterspeech.GetComponent<Playerspeech>().setspeechtext("뒤에서 누군가 쫓아오는 소리가 들린다.","","","","");
            canplay = false; //한번 대사했으면 다시 X

        }

        
    }
}
