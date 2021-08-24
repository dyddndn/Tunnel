using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)){
            gameObject.tag = "Crouching"; //��Ʈ�� ���� �� �ش� ������Ʈ(�÷��̾�)�� �±� ����
            gameObject.GetComponent<PlayerMove>().enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            gameObject.tag = "Player";
            gameObject.GetComponent<PlayerMove>().enabled = true;
        }

    }
}
