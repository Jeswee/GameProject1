//using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]     // ensures rigidbody2d always exists
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    //[SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float desiredJumpHeight = 3f;
    [SerializeField] float verticalSpeed = 3;
    private Rigidbody rb;
    private BoxCollider box;
    public bool isAlive = true;
    //[SerializeField] public float gravity;        //for now in difficulty manager

    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();

    }


    private void OnCollisionEnter(Collision other)
    {
        // if not flagged
        rb.linearVelocity = Vector3.zero;
        //rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        //rb.linearVelocity += new Vector3(0, _jumpForce, 0);           //old velocity!!!
        rb.linearVelocity += new Vector3(0, Mathf.Sqrt(-2 * Physics.gravity.y * desiredJumpHeight), 0);     //Rechnung für velocity für desired Jump Hieght
        Debug.Log("Me is colliding!!!!");
    }

    void OnCollisionExit(Collision collision)
    {
        // remove flag
    }

    // Update is called once per frame
    void Update()
    {
        
        //Physics.gravity = new Vector3(0f, gravity, 0f);   //for now in difficulty manager

        if (isAlive)
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
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.y <= 0 && isAlive)
        {
            box.enabled = true;
        }
        else
        {
            box.enabled = false;
        }
        //Debug.Log(rb.linearVelocity.y);

    }

    // jump to specific height:
        //initialVelocity = Mathf.Sqrt(-2f*gravity*jumpHeight)      --> https://youtu.be/V5x9q433rmE?si=sQX_1eTE0SlQnP4o
}
