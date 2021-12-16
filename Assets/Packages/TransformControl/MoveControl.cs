using UnityEngine;

public class MoveControl : MonoBehaviour
{
    Transform _transform;
    public float speed = 1;
    public Space space = Space.Self;

    //public bool rigidMode;
    //Rigidbody rig;

    void Start()
    {
        // if (rigidMode)
        // {
        //     rig = _transform.GetComponent<Rigidbody>();
        // }
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _transform.Translate(Vector3.right * speed * Time.deltaTime, space);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _transform.Translate(Vector3.left * speed * Time.deltaTime, space);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _transform.Translate(Vector3.forward * speed * Time.deltaTime, space);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _transform.Translate(Vector3.back * speed * Time.deltaTime, space);
        }

        if (Input.GetKey(KeyCode.E))
        {
            _transform.Translate(Vector3.up * speed * Time.deltaTime, space);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            _transform.Translate(Vector3.down * speed * Time.deltaTime, space);
        }

        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     rig.AddForce(Vector3.right * speed, ForceMode.Impulse);
        // }
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     rig.AddForce(Vector3.left * speed, ForceMode.Impulse);
        // }

        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     rig.AddForce(Vector3.up * speed, ForceMode.Impulse);
        // }
        // if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     rig.AddForce(Vector3.down * speed, ForceMode.Impulse);
        // }

    }


    private void OnGUI()
    {
        GUILayout.Label("Move Speed :" + speed.ToString());
        if (GUILayout.Button("Speed ++"))
        {
            speed++;
        }
        if (GUILayout.Button("Speed --"))
        {
            speed--;
        }
    }
}