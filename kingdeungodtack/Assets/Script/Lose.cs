using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == zombie)
        {
            //SceneManager.LoadScene(""); //이름으로 찾아 씬실행(다음화면으로)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //재시작

        }
    }
}
