using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
public float Speed = 1.0f;

public float RotationSpeed = 1.0f;

public Animator animator;

public float JumpForce = 1f;

public Transform groundCheck;
public float groundDistance=0.1f;
public LayerMask groundMask;
bool isGrounded;


public Rigidbody Physicas;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Physicas = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * Speed);
        //rotacion
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed * 100, 0));
        
        
        animator.SetFloat("VelX", horizontal);
        animator.SetFloat("VelY", vertical);

        if (Input.GetKey("1")){
            animator.SetBool("Other",false);
            animator.Play("Dance");

        }
        if (Input.GetKey("2")){
            animator.SetBool("Other",false);
            animator.Play("Dance2");
        }
        
        if (horizontal>0 || horizontal<0 || vertical>0 || vertical<0){
            animator.SetBool("Other",true);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //salto
        if (Input.GetKey("space") && isGrounded){
            animator.Play("Jump");
            //Physicas.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            Physicas.AddForce(Vector3.up*JumpForce, ForceMode.Impulse);
        }
        
    }
    

}