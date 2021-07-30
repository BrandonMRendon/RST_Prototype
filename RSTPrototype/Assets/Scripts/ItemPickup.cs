using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Gun weapon;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            gameObject.transform.parent = collision.gameObject.GetComponent<PlayerController>().pivot;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            PlayerController.Instance.weapon = weapon;
            Destroy(this);
        }
    }
}
