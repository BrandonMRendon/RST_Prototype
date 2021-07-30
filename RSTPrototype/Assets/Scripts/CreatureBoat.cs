using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureBoat : MonoBehaviour
{
    public AudioSource audioS, fullAudio;
    public AudioClip screech, thridMalformation;
    public Animator anim;
    public NavMeshAgent agent;
    public Transform target;
    bool animationEnded, dead;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        animationEnded = false;
        dead = false;
        health = 200;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            PlayerController.Instance.targetedEnemy = transform;
        }
    }
    public void Begin()
    {
        anim.SetTrigger("Boat");
        audioS.PlayOneShot(screech);
        fullAudio.Stop();
        fullAudio.PlayOneShot(thridMalformation);
    }
    public void AnimationEnded()
    {
        animationEnded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (animationEnded && !dead)
        {
            agent.SetDestination(target.position);

            if (Vector3.Distance(transform.position, target.position) < 2)
            {
                anim.SetTrigger("Proximity");
            }
        }
        if(health <= 0)
        {
            dead = true;
            anim.SetTrigger("Death");
        }
        
    }
}
