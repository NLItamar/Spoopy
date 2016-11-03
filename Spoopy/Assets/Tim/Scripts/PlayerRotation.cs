using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 50;
    float yRotation = 0;
    float xRotation = 0;

    void Update()
    {
        yRotation -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -80, 80);
        xRotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        xRotation = xRotation % 360;
        transform.localEulerAngles = new Vector3(yRotation, xRotation, 0);
    }
}
