using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPlayerController : MonoBehaviour
{
    //Movement Variables
    public float verticalInput;
    public float moveSpeed;

    private float horizontalInput;
    public float turnSpeed;

    //Jumping Variables
    private Rigidbody rb;
    public float jumpForce;
    public bool isOnGround;

    //Animation Variables
    private Animator animator;

    public ParticleSystem dust;


    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        dust.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        //Forward and Backward Movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
        animator.SetFloat("VerticalInput", Mathf.Abs(verticalInput));

        if(verticalInput > 0 && isOnGround && !dust.isPlaying)
        {
            //dust.gameObject.SetActive(true);
            dust.Play();
        }
        else if (verticalInput <= 0 && !isOnGround && dust.isPlaying)
        {
            //dust.gameObject.SetActive(false);
            dust.Stop();
        }

        //Rotation
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        //Jumping
        if(Input.GetKeyDown(KeyCode.Space)  && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (isOnGround)
        {
            animator.SetBool("OnGround", true);
        }
        else if (!isOnGround)
        {
            animator.SetBool("OnGround", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("shoot");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
