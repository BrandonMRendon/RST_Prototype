using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSteve : MonoBehaviour
{
    public GameObject SteveNav, Steve;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Steve.SetActive(false);
            SteveNav.SetActive(true);
        }
    }
}
