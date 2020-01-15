using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public Transform groundcheck;
    public float groundcheckradius;
    public LayerMask whatisground;
    private bool onground;
    private bool yes;
    private bool hub;
    private bool roll;
    private bool clone;
    public GameObject chair1;
    public Rigidbody2D chair;
    public Vector3 OriginalPos;
    public float xAngle, yAngle, zAngle;
    public float yPos;
    void Awake()
    {
        OriginalPos = transform.position;
        gameObject.transform.position = new Vector3(-0.75f, 0.0f, 0.0f);
        gameObject.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);


    }
    void Start()
    {
        clone = false;
        roll = true;
        hub = true;
        yes = false;
        chair = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (roll == true)
        {
            chair.velocity = new Vector2(chair.velocity.x, 0.4f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            yes = true;
            hub = false;
            roll = false;
            clone = true;
            for (int b = 0; b < 1; b++)
            {
                yPos += 0.05f;
            }
        }
        if (clone == true)
        {
            Instantiate(chair1, new Vector3(-0.5f, yPos, 0.0f), Quaternion.identity);
        }
        gameObject.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        onground = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, whatisground);
        if (hub == true)
        {
            transform.position = OriginalPos;
        }

        if (yes == true)
        {
            gameObject.transform.Rotate(0.0f, 0.0f, -2.0f, Space.Self);
        }
    }

}
