using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    Rigidbody rb;
    public DynamicJoystick dynamicJoystick;
    public float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void JoystickMoving()
    {

        rb.velocity = new Vector3(dynamicJoystick.Horizontal * speed, rb.velocity.y, dynamicJoystick.Vertical * speed);

        float angleA = Mathf.Atan2(dynamicJoystick.Horizontal, dynamicJoystick.Vertical) * Mathf.Rad2Deg;

        if (angleA != 0)
            transform.rotation = Quaternion.Euler(0f, angleA, 0f);

    }

    public void StopMoving()
    {
        rb.velocity = Vector3.back * 1.5f;
    }
}
