using System;
using UnityEngine;

public class RotateControl : MonoBehaviour
{
    public bool rotateAroundmode;
    [Tooltip("to rotate around")]
    public Transform _transform;

    public float speedStep = 0.1f;
    public float x_speed = 30;
    public float y_speed = 30;
    public float z_speed = 30;
    public Space space = Space.Self;
    void Start()
    {
        if (!rotateAroundmode)
        {
            _transform = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            x_speed = y_speed = z_speed = 0;
        }

        if (rotateAroundmode)
        {
            RotateAround();
            return;
        }
        NormalRotate();

    }

    private void NormalRotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            x_speed += speedStep;
            //_transform.Rotate(Vector3.right * x_speed * Time.deltaTime, space);
        }

        if (Input.GetKey(KeyCode.A))
        {
            x_speed -= speedStep;
            //_transform.Rotate(Vector3.left * x_speed * Time.deltaTime, space);
        }

        if (Input.GetKey(KeyCode.W))
        {
            z_speed += speedStep;
            //_transform.Rotate(Vector3.forward * z_speed * Time.deltaTime, space);
        }
        if (Input.GetKey(KeyCode.S))
        {
            z_speed -= speedStep;
            //_transform.Rotate(Vector3.back * z_speed * Time.deltaTime, space);
        }

        if (Input.GetKey(KeyCode.E))
        {
            y_speed += speedStep;
            //_transform.Rotate(Vector3.up * y_speed * Time.deltaTime, space);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            y_speed -= speedStep;
            //_transform.Rotate(Vector3.down * y_speed * Time.deltaTime, space);
        }

        // method 1
        _transform.Rotate(Vector3.right * x_speed * Time.deltaTime, space);
        _transform.Rotate(Vector3.forward * z_speed * Time.deltaTime, space);
        _transform.Rotate(Vector3.up * y_speed * Time.deltaTime, space);

        // method 2
        // _transform.rotation = Quaternion.Euler(x_speed, y_speed, z_speed);
    }

    private void RotateAround()
    {
        if (Input.GetKey(KeyCode.D))
        {
            x_speed += speedStep;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x_speed -= speedStep;
        }
        if (Input.GetKey(KeyCode.W))
        {
            z_speed += speedStep;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z_speed -= speedStep;
        }

        if (Input.GetKey(KeyCode.E))
        {
            y_speed += speedStep;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            y_speed -= speedStep;
        }

        transform.RotateAround(_transform.position, Vector3.right, x_speed);
        transform.RotateAround(_transform.position, Vector3.forward, z_speed);
        transform.RotateAround(_transform.position, Vector3.up, y_speed);

    }
}