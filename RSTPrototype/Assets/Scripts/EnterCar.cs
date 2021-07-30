using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCar : MonoBehaviour
{
    private bool enterable;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterable = true;
        }
            
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            enterable = false;
        }
            
    }
    private void Update()
    {
        if (enterable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerController.Instance.EnterVehichle(transform.parent.gameObject);
            }
        }
    }
}
