using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemconfirm : MonoBehaviour
{
    public GameObject itemEkey;
    public GameObject QDiary;
    bool QDiarycheck = false;
    public GameObject Screen;
    public GameObject Screenimage;
    public GameObject book1;
    public GameObject book1image;
    bool Screensomething = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        itemEkey.SetActive(!Screensomething); //뭔가가 보여지고 있으면 획득표시 없애기
        Screen.SetActive(Screensomething); //뭔가가 보여지고 있으면 화면 보여주기

        if(Screensomething && Input.GetKeyDown(KeyCode.Escape))
        {
            Screensomething = false; //보여지지 않도록
        }

            RaycastHit hit; //Raycast 맞는 물체 hit 정의
        //Debug.DrawRay(Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)), Camera.main.transform.forward*100f, Color.red);
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, 5)) //카메라 포지션에서 카메라 방향으로 5만큼 거리의 레이캐스트 발사해서 hit가 맞으면
        {
            //GameObject hitObj = hit.collider.gameObject; //맞는 물체가 hit였고 hit의 콜라이더의 오브젝트를 hitObj에 넣음
            if ((hit.collider.gameObject.tag == "book" || hit.collider.gameObject.tag == "key") && !Screensomething) //book이거나 key이고 아무것도 안뜬상태면
            {
            itemEkey.SetActive(true); //레이캐스트에 걸린게 책이나 열쇠고 아무것도 읽고있지 않으면 획득버튼뜨게


                if (hit.collider.gameObject.name=="book1" && Input.GetKeyDown(KeyCode.E)) //그 책의 이름이 book1이고 E키를 누르면
                {
                    Screenimage.GetComponent<Image>().sprite = book1image.GetComponent<Image>().sprite; //보여질 화면의 그림에 보여줄 화면의 그림 대입
                    Screensomething = true; //보여지도록
                }

                    
            }
            else //레이캐스트에 걸린게 다른 것들이라면
            {
            itemEkey.SetActive(false); //획득 안뜨게

            }

        }
        else //레이캐스트에 걸린게 없으면
        {
            itemEkey.SetActive(false); //획득 안뜨게
        }
        
        
        
        
        QDiary.SetActive(QDiarycheck); //QDiarycheck에 따라 활성화, 비활성화
        if (Input.GetKeyDown(KeyCode.Q)) //Q누르면
        {
            QDiarycheck = !QDiarycheck; //Q체크전환(즉, Q 활성화 비활성화)
        }

    }
}
