//using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]     // ensures rigidbody2d always exists
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] float verticalSpeed = 3;
    private Rigidbody rb;
    BoxCollider box;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
    }


    private void OnCollisionEnter(Collision other)
    {
        // if not flagged
        rb.linearVelocity = Vector3.zero;
        //rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        rb.linearVelocity += new Vector3(0, _jumpForce, 0);
        Debug.Log("Me is colliding!!!!");
    }

    void OnCollisionExit(Collision collision)
    {
        // remove flag
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = new Vector3(verticalSpeed, rb.linearVelocity.y, 0);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = new Vector3(-verticalSpeed, rb.linearVelocity.y, 0);
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
       
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.y <= 0)
        {
            box.enabled = true;
        }
        else
        {
            box.enabled = false;
        }
        Debug.Log(rb.linearVelocity.y);

        

    }

}
