using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);       
    }

    // Update is called once per frame
    void Update()
    {

    }

}
