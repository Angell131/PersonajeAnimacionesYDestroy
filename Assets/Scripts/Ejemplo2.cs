using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo2 : MonoBehaviour
{
    
    public float runSpeed = 7.0f;
    public float rotationSpeed = 250f;
    
    public Animator animator;
    private float x,y;
    
    public Rigidbody rb;
    public float JumpHeight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
        
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
        
        if (Input.GetKey("1")){
            animator.SetBool("Other",false);
            animator.Play("Dance");

        }
        if (Input.GetKey("2")){
            animator.SetBool("Other",false);
            animator.Play("Dance2");
        }
        if (x>0 || x<0 || y>0 || y<0){
            animator.SetBool("Other",true);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //salto
        if (Input.GetKey("space") && isGrounded){
            animator.Play("Jump");
            //Physicas.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
        }
        
        
    }

    
}
