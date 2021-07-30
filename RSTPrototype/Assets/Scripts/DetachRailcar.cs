using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetachRailcar : MonoBehaviour
{
    public GameObject lever;
    public Slider slider;
    bool isNear;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            lever.SetActive(true);
            isNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lever.SetActive(false);
            isNear = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isNear = false;
        StartCoroutine("TickDown");
    }
    IEnumerator TickDown()
    {
        while (true)
        {
            if(slider.value > 0)
            {
                slider.value -= .1f;
            }
            
            yield return new WaitForSeconds(.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.Space)) {
            slider.value += 1;
        }
    }
}
