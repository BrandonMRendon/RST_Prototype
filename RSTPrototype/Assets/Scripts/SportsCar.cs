using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportsCar : MonoBehaviour, IVehichle
{
    public float speed { get; set; }
    public Transform CameraLocation { get; set; }

    public Transform camLoc;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20;
        CameraLocation = camLoc;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
