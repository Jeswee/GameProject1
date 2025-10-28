//using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]     // ensures rigidbody2d always exists
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;

    private Rigidbody rb;
    BoxCollider box;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
    }


    private void OnCollisionEnter(Collision other)
    {
        // if not flagged
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        Debug.Log("Me is colliding!!!!");
    }

    void OnCollisionExit(Collision collision)
    {
        // remove flag
    }

    // Update is called once per frame
    void Update()
    {

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
