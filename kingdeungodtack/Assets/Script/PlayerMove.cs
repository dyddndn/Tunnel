using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 350;
    CharacterController charCtrl;
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
      

        // 1. 사용자의 입력에 따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. 앞뒤 좌우로 방향을 만든다.
        Vector3 dir = Vector3.right * h + Vector3.forward * v;

        //카메라가 보고있는 방향을 앞 방향으로 변경한다.
        dir = Camera.main.transform.TransformDirection(dir);
        //로컬스페이스에서 월드스페이스로 변환 해준다. (트렌스폼 기준으로 결과를 바꾼다.)
        dir = new Vector3(dir.x, 0, dir.z);

        dir.Normalize();
        // 3. 그 방향으로 이동한다.
        // P = P0 + vt
        //transform.position += dir * speed * Time.deltaTime;
        charCtrl.SimpleMove(dir * speed * Time.deltaTime);
    }


}
