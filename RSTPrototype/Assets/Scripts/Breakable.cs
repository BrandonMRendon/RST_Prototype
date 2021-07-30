using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    AudioSource audioS;
    public AudioClip clip;
    // Start is called before the first frame update
    public EnableEstateCreature creature;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            creature.ChangeTarget(transform);
            audioS.PlayOneShot(clip);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
