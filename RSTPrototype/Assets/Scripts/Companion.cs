using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Companion : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject bulletPrefab;
    public AudioSource audioS;
    public AudioClip shot;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance.GetComponent<Transform>();
        StartCoroutine("ShootPlayer");
    }
    IEnumerator ShootPlayer()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(1);
            if(PlayerController.Instance.targetedEnemy != null)
            {
                // Instantiate the projectile at the position and rotation of this transform
                GameObject projectile;
                projectile = Instantiate(bulletPrefab, transform.position + new Vector3(0, .5f, 0), transform.rotation);
                //projectile.GetComponent<Rigidbody>().AddForce(transform.forward * shootingStrength, ForceMode.Impulse);
                // Give the cloned object an initial velocity along the current
                // object's Z axis
                projectile.GetComponent<Rigidbody>().velocity = (PlayerController.Instance.targetedEnemy.position - transform.position) * 5;
                audioS.PlayOneShot(shot);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
