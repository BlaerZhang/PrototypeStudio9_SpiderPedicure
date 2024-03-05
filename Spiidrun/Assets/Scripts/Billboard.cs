using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera camera;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // float rotationY = Quaternion.LookRotation(Vector3.forward, camera.transform.position).eulerAngles.z;
        // transform.rotation = Quaternion.Euler(new Vector3(90, 0, rotationY));
        transform.rotation = Quaternion.LookRotation(Vector3.down, camera.transform.position);
    }
}
