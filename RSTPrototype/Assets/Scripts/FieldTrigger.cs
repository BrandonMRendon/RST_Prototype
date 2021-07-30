using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTrigger : MonoBehaviour
{
    public GameObject monsterField, Steve1;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            monsterField.SetActive(true);
            anim.SetTrigger("Field");
            Steve1.SetActive(false);
            PlayerController.Instance.inField = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
