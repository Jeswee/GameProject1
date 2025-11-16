//using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]     // ensures rigidbody2d always exists
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    //[SerializeField] private float _jumpForce = 10f;
    [SerializeField] public float desiredJumpHeight = 4f;
    [SerializeField] float verticalSpeed = 6;
    float jumpMultiplier = 1;
    private Rigidbody rb;
    private BoxCollider box;
    public bool isAlive = true;
    [SerializeField] public float gravity; // = Physics.gravity.y;

    private Animator animator;

    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        GameManager.instance.switchGameState(GameState.RUNNING);        //REMOVING BREAKS GAME ---- TODO: FIX MENU & RESTART
    }

    private void OnCollisionEnter(Collision other)
    {
        animator.SetTrigger("collided");

        if (other.collider.CompareTag("platform"))
        {
            jumpMultiplier = other.gameObject.GetComponent<Platform>().jumpMultiplier;
            SoundEffectsManager.instance.PlayRandomSoundEffect(other.gameObject.GetComponent<Platform>().sfx, this.transform, 1);
        }
        
        // if not flagged
        rb.linearVelocity = Vector3.zero;
        //rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        //rb.linearVelocity += new Vector3(0, _jumpForce, 0);           //old velocity!!!
        rb.linearVelocity += new Vector3(0, Mathf.Sqrt(-2 * Physics.gravity.y * desiredJumpHeight * jumpMultiplier), 0);     //Rechnung für velocity für desired Jump Hieght
        Debug.Log("Me is colliding!!!!");
    }

    void OnCollisionExit(Collision collision)
    {
        // remove flag
    }

    // Update is called once per frame
    void Update()
    {
        
        Physics.gravity = new Vector3(0f, gravity, 0f);

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
