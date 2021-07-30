using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTrigger : MonoBehaviour
{
    public CreatureBoat creature;
    bool hasStarted;
    private void Start()
    {
            hasStarted = false;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!hasStarted && other.gameObject.tag == "Player")
        {
            creature.gameObject.SetActive(true);
            creature.Begin();
            hasStarted = true;
        }
    }
}
