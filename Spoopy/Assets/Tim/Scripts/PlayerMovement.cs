using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float startingSpeed = 100f;
    public float increaseSpeed = 12.5f;
    private float bonusSpeed = 0f;

    private float currentSpeed = 0f;
    private bool moving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        bool movingLastFrame = moving;
        Vector3 deltaPosition = Vector3.zero;

        if (moving && bonusSpeed < (startingSpeed / 10))
        {
            bonusSpeed += increaseSpeed;
        }

        moving = false;

        CheckMovement(KeyCode.W, ref deltaPosition, transform.forward);
        CheckMovement(KeyCode.S, ref deltaPosition, -transform.forward);
        CheckMovement(KeyCode.D, ref deltaPosition, transform.right);
        CheckMovement(KeyCode.A, ref deltaPosition, -transform.right);

        if (moving)
        {
            if (!movingLastFrame)
            {
                currentSpeed = startingSpeed;
            }          
            rb.AddForce(deltaPosition  * (currentSpeed + bonusSpeed));
        }
        else
        {
            currentSpeed = 0f;
        }
    }

    private void CheckMovement(KeyCode keyCode, ref Vector3 deltaPosition, Vector3 directionVector)
    {
        if (Input.GetKey(keyCode))
        {
            moving = true;
            deltaPosition += directionVector;
        }
    }
}

