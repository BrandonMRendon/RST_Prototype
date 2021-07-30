using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    public GameObject bulletPrefab;
    public int Damage { get; set; }
    public AudioSource audioS;
    public AudioClip shot;

    public void Attack()
    {
        audioS.PlayOneShot(shot);
            // Instantiate the projectile at the position and rotation of this transform
            GameObject projectile;
            projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //projectile.GetComponent<Rigidbody>().AddForce(transform.forward * shootingStrength, ForceMode.Impulse);
            // Give the cloned object an initial velocity along the current
            // object's Z axis
            projectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.up * 30);
    }
  
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Change to be inside player class
        
    }
}
