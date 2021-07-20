using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    public AudioClip stepsound;
    float soundtime = 0.0f;
    bool cansound = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = stepsound;
    }

    // Update is called once per frame
    void Update()
    {
        soundtime += Time.deltaTime;

        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (dir.sqrMagnitude > 0.1f && soundtime > 0.5f)
        {
            GetComponent<AudioSource>().Play();
            cansound = false;
            soundtime = 0.0f;
        }
    }
}
