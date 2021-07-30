using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject bullet;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(bullet);
    }
}
