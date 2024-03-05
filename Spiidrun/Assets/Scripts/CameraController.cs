using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    [Range(0, 24)]
    public float distance = 1.0f;
    public Vector3 rotation;
    public Transform target;
    public float scrollSensitivity;
    public float mouseSensitivity;

    void Update()
    {
        if (target == null)
            return;
        transform.position = target.position + Quaternion.Euler(rotation) * (Vector3.forward * distance);
        transform.LookAt(target);

        if (distance <= 0) distance = 0.1f;

        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

        if (Input.GetMouseButton(1))
        {
            rotation += new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * mouseSensitivity;
        }
    }
}
