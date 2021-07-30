using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGoal : MonoBehaviour
{
    public GameObject Creature;
    public AudioSource audioS;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Creature.SetActive(false);
            audioS.Stop();
            audioS.Play();
        }
    }
}
