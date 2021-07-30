using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public Animator anim;
    public GameObject monster2, creatureFull;
    public float health, backOff;
    public Transform window1, window2, window3, window4, window5, window6;
    public Transform[] windows;
    public AudioSource monsterAudio, fullAudio;
    public AudioClip growl, screech, thump, suspense;
    // Start is called before the first frame update
    void Start()
    {
        health = 500;
        backOff = 490;
        windows = new Transform[] { window1, window2, window3, window4, window5, window6 };
        StartCoroutine("Left");
    }
    public Transform SelectWindow()
    {
        
        return windows[Random.Range(0, 6)];
        
    }
    IEnumerator ChangeWindow()
    {
        fullAudio.PlayOneShot(thump);
        fullAudio.PlayOneShot(growl);
        int delay = Random.Range(7, 15);
        yield return new WaitForSeconds(delay);
        Transform window = SelectWindow();
        monster2.SetActive(true);
        creatureFull.transform.position = window.position;
        creatureFull.transform.rotation = window.rotation;
        monsterAudio.PlayOneShot(thump);
        monsterAudio.PlayOneShot(screech);
        print("WINDOW SELECTED");
        anim.SetTrigger("Return");


    }
    IEnumerator Left()
    {
        yield return new WaitForSeconds(70);
        fullAudio.Stop();
        fullAudio.PlayOneShot(suspense);
        creatureFull.SetActive(false);
    }
    IEnumerator BackedOff()
    {
        yield return new WaitForSeconds(1);
        monster2.SetActive(false);
        
        StartCoroutine("ChangeWindow");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(health <= backOff)
        {
            anim.SetTrigger("BackOff");
            StartCoroutine("BackedOff");
            backOff -= 10;
        }
    }
}
