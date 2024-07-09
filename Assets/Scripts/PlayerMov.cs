using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int speed;

    public float jumpHeight = 1.0f;
    public bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f); // verticalInput);

        if (isGrounded == true) //mientras estes en el piso, se podra saltar, es para evitar volar
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                rb.AddForce(Vector3.up * jumpHeight);
                isGrounded = false;
                Debug.Log("Estas saltando");
            }
            Debug.Log("Estas en el piso");
        }

        

        movement.Normalize();

        transform.Translate(movement * Time.deltaTime * speed); //para moverse a los costados segun el player
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}