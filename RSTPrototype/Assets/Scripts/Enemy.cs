using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int Damage { get; set; }
    public AudioSource audioS;
    public AudioClip shot;
    Transform playerTransform;
    public float health;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = PlayerController.Instance.GetComponent<Transform>();
        audioS = GetComponent<AudioSource>();
        StartCoroutine("ShootPlayer");
        health = 5;
    }
    
    IEnumerator ShootPlayer()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(2, 4));
            if(Vector3.Distance(playerTransform.position , transform.position) < 7)
            {
                // Instantiate the projectile at the position and rotation of this transform
                GameObject projectile;
                projectile = Instantiate(bulletPrefab, transform.position + new Vector3(0, .5f, 0), transform.rotation);
                //projectile.GetComponent<Rigidbody>().AddForce(transform.forward * shootingStrength, ForceMode.Impulse);
                // Give the cloned object an initial velocity along the current
                // object's Z axis
                projectile.GetComponent<Rigidbody>().velocity = (playerTransform.position - transform.position) * 5;
                audioS.PlayOneShot(shot);
            }
            
            
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            PlayerController.Instance.targetedEnemy = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(enemy);
        }
    }
}
