// Resharper disable all

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motinn : MonoBehaviour
{
    public enum MotionType
    {
        Rotation,
        Location
    }

    public bool isMotion, isLocal;
    public Vector3 direction;
    public float speed;

    [SerializeField] MotionType motionType;

    [SerializeField] KeyCode StartActionKey = KeyCode.G;
    [SerializeField] KeyCode StopActionKey = KeyCode.H;
    [SerializeField] KeyCode ReverseActionKey = KeyCode.F;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(StartActionKey))
        {
            StartAction();
        }

        if (Input.GetKeyDown(StopActionKey))
        {
            StopAction();
        }

        if (Input.GetKeyDown(ReverseActionKey))
        {
            Reverse();
        }
    }

    void FixedUpdate()
    {
        if (!isMotion)
        {
            return;
        }

        Action();
    }

    public void StartAction()
    {
        isMotion = true;
    }

    public void StopAction()
    {
        isMotion = false;
    }

    public void Reverse()
    {
        direction = -direction;
    }

    void Action()
    {
        switch (motionType)
        {
            case MotionType.Location:
                transform.Translate(direction * speed * Time.deltaTime, isLocal ? Space.Self : Space.World);
                break;
            case MotionType.Rotation:
                transform.Rotate(direction * speed * Time.deltaTime, isLocal ? Space.Self : Space.World);
                break;
        }
    }
}