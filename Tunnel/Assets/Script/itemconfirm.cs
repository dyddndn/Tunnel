using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemconfirm : MonoBehaviour
{
    float timeforrequirekey = 5.0f;

    public GameObject itemEkey;
    public GameObject YoucancheckQDiary;
    public GameObject QDiarypaper;
    public GameObject QDiarytext;
    Text QDiarytxt;

    bool QDiarycheck = false;
    public GameObject Screen;
    public GameObject Screenimage;
    bool Screensomething = false;


    public GameObject dooraudioobject;
    AudioSource dooraudiosource;

    public GameObject paperaudioobject;
    AudioSource paperaudiosource;

    public GameObject keygetaudioobject;
    AudioSource keygetaudiosource;

    public GameObject requirekey;
    bool requirekeyon = false;

    public GameObject PlayerInventory;
    PlayerInventory inven;

    public GameObject book1;
    public GameObject book2;

    // Start is called before the first frame update
    void Start()
    {
        QDiarytxt = QDiarytext.GetComponent<Text>();
        inven = PlayerInventory.GetComponent<PlayerInventory>();
        DiaryContentChange(1);
        dooraudiosource = dooraudioobject.GetComponent<AudioSource>();
        paperaudiosource = paperaudioobject.GetComponent<AudioSource>();
        keygetaudiosource = keygetaudioobject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        itemEkey.SetActive(!Screensomething); //뭔가가 보여지고 있으면 획득표시 없애기
        Screen.SetActive(Screensomething); //뭔가가 보여지고 있으면 화면 보여주기
        YoucancheckQDiary.SetActive(!Screensomething); //보여지고 있으면 Q일지 가능 화면 없애기
        requirekey.SetActive(requirekeyon);

        if(Screensomething && Input.GetKeyDown(KeyCode.Escape)) //뭔가 보여지고 있을 때 ESC를 누르면
        {
            paperaudiosource.Play();
            Screensomething = false; //보여지지 않도록
            QDiarycheck = false;
        }

            RaycastHit hit; //Raycast 맞는 물체 hit 정의
        //Debug.DrawRay(Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)), Camera.main.transform.forward*100f, Color.red);
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, 3)) //카메라 포지션에서 카메라 방향으로 5만큼 거리의 레이캐스트 발사해서 hit가 맞으면
        {
            if ((hit.collider.gameObject.tag == "book"))// hit의 태그가 book이면
            {
                itemEkey.GetComponent<Text>().text = "E 읽기";
                itemEkey.SetActive(true);
            }
            else if (hit.collider.gameObject.tag == "door")//hit의 태그가 door면
            {
                itemEkey.GetComponent<Text>().text = "E 열기";
                itemEkey.SetActive(true);
            } else if (hit.collider.gameObject.tag == "key")//hit의 태그가 key면
            {
                itemEkey.GetComponent<Text>().text = "E 획득";
                itemEkey.SetActive(true);
            }
            else
            {
                itemEkey.GetComponent<Text>().text = "";
                itemEkey.SetActive(false);
            }

            //GameObject hitObj = hit.collider.gameObject; //맞는 물체가 hit였고 hit의 콜라이더의 오브젝트를 hitObj에 넣음
            
                if (hit.collider.gameObject.name=="book1" && Input.GetKeyDown(KeyCode.E)&&!Screensomething) //그 책의 이름이 book1이고 E키를 누르면
                {
                    paperaudiosource.Play();
                    Screenimage.GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite; //스크린의 스프라이트를 레이캐스트에 맞은 hit의 image컴포넌트의 스프라이트로 바꿈
                    Screensomething = true; //보여지도록
                    book1.GetComponent<AudioSource>().Play();
                }

                if(hit.collider.gameObject.name=="book2" && Input.GetKeyDown(KeyCode.E)&&!Screensomething)
                {
                    paperaudiosource.Play();
                    Screenimage.GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite; //보여질 화면의 그림에 보여줄 화면의 그림 대입
                    Screensomething = true; //보여지도록
                    book2.GetComponent<AudioSource>().Play();
                }

                if (hit.collider.gameObject.name=="door1"&&Input.GetKeyDown(KeyCode.E)&&!Screensomething)
                {
                    if (inven.findinven("key1")) //key1 이름이 있는지 찾음
                    {
                        hit.collider.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
                        dooraudiosource.Play();
                    }
                    else if (!inven.findinven("key1"))
                {
                    timeforrequirekey = 0.0f;
                }
                }

                if(hit.collider.gameObject.name == "key1" && Input.GetKeyDown(KeyCode.E) && !Screensomething) //열쇠 먹을 때
            {
                hit.collider.gameObject.SetActive(false);
                inven.intoinven(hit.collider.gameObject);
                keygetaudiosource.Play();

            }

        }

        else //레이캐스트에 걸린게 없으면
        {
            itemEkey.SetActive(false); //획득 안뜨게
        }
        
        
        
        
        QDiarypaper.SetActive(QDiarycheck); //QDiarycheck에 따라 활성화, 비활성화
        if (Input.GetKeyDown(KeyCode.Q) && !Screensomething) // 아무것도 안보여지고 있을 때 Q누르면
        {
            paperaudiosource.Play();
            Screensomething = true;
            QDiarycheck = !QDiarycheck; //Q체크전환(즉, Q 활성화 비활성화)
        }


        timeforrequirekey += Time.deltaTime;
        if (timeforrequirekey < 5.0f)
        {
            requirekeyon = true;
        }
        else
        {
            requirekeyon = false;
        }
    }

    void DiaryContentChange(int phase)
    {
        switch (phase)
        {
            case 1:
            QDiarytxt.text = "집으로 돌아가던 중 오래된 터널에 떨어졌다.\n놀라운건 여기 누가 살았던 흔적이 있다는 것이다.\n터널을 빠져나갈 방법을 찾아보자.";
                break;
    }
        
    }
}
