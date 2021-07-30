using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Transform to;
    public AudioSource audioS;
    public AudioClip clip;
    public bool isAudio, isObject, isActive, stopAudio, playField;
    public GameObject objects, destroy;
    public Text text;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            PlayerController.Instance.controller.enabled = false;
            PlayerController.Instance.transform.position = to.position + new Vector3(0, .5f, 0);
            PlayerController.Instance.controller.enabled = true;
            text.text = "";
            if (stopAudio)
            {
                audioS.Stop();
            }
            if (isAudio)
            {
                audioS.PlayOneShot(clip);
            }
            
            if (playField)
            {
                audioS.Stop();
                audioS.Play();
            }
            if (isObject)
            {
                objects.SetActive(isActive);
            }
            if (destroy != null)
            {
                Destroy(destroy);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
