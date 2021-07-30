using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureTrigger1 : MonoBehaviour
{
    public Animator anim;
    public GameObject monster2, Steve;
    public AudioSource audioS;
    public AudioClip firstMalformation, screech, glass;
    private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        monster2.SetActive(false);
        isPlaying = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isPlaying)
        {
            audioS.Stop();
            audioS.PlayOneShot(firstMalformation);
            audioS.PlayOneShot(screech);
            audioS.PlayOneShot(glass);
            isPlaying = true;
            monster2.SetActive(true);
            anim.SetTrigger("Bed");
            Steve.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
