using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    public GameObject clone;
    public GameObject parent;
    public GameObject toDestroy;

    private void Awake()
    {
        Destroy(toDestroy);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Spawn")
        {
            clone = Instantiate(obj, transform.position, transform.rotation);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Spawn")
        {
            Destroy(clone);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Spawn")
        {
            clone = Instantiate(obj, transform.position, transform.rotation, parent.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Spawn")
        {
            Destroy(clone);
        }
    }

}
