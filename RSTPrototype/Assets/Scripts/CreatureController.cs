using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioS;
    public AudioClip scurry;
    public GameObject steve;
    private bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !isPlaying)
        {
            audioS.PlayOneShot(scurry);
            isPlaying = true;
            anim.SetTrigger("Window");
            steve.SetActive(false);
        }
        
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
