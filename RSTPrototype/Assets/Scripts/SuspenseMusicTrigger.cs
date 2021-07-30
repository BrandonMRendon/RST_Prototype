using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspenseMusicTrigger : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip suspense;
    public Navigation nav;
    public Transform target2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioS.Stop();
            audioS.PlayOneShot(suspense);
            nav.target = target2;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
