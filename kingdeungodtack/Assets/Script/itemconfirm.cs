using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemconfirm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            RaycastHit hit; //맞는 물체가 hit
        Debug.DrawRay(Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)), Camera.main.transform.forward*100f, Color.red);
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, 30)) //out hit로 무언가 맞을 시
            {
                GameObject hitObj = hit.collider.gameObject; //맞는 물체가 hit였고 hit의 콜라이더의 오브젝트를 hitObj에 넣음
                if (hitObj.tag == "book")
                {
                Debug.Log("asdf");
                }
                else if (hitObj.tag == "Player")
                {
                }

        }
    }
}
