using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantBomb : MonoBehaviour
{
    public GameObject bomb, lights, trigger;
    bool isNear, notSet;
    public AudioSource audioS;
    public AudioClip boom;
    public Text text;
    public float timer;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bomb.SetActive(true);
            isNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bomb.SetActive(false);
            isNear = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isNear = false;
        notSet = true;
        timer = 420;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.Space)  && notSet)
        {
            notSet = false;
            bomb.SetActive(false);
            lights.SetActive(true);
            trigger.SetActive(true);
            audioS.Stop();
            audioS.PlayOneShot(boom);
        }
    }
    private void FixedUpdate()
    {
        if (!notSet)
        {
            timer -= Time.deltaTime;
            text.text = "" + timer;

            var ts = TimeSpan.FromSeconds(timer);
            text.text = string.Format("{0:00}:{1:00}:{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
    }
}
