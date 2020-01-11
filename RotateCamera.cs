using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Dit zorgt ervoor dat we in Unity een waarde kunnen geven voor de snelheid.
    public float rotationSpeed;

    // Dit update alle scripts per frame.
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
