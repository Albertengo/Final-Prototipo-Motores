using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMov : MonoBehaviour
{
    //NOTA: PLAYER NO SE MUEVE, se queda en el lugar mientras el mapa se mueve a su alrededor.

    [SerializeField] private Rigidbody rb;
    [SerializeField] private int speed;

    public float jumpHeight = 1.0f;
    public bool isGrounded;

    public static int Coins;

    //
    public static event Action OnEnemyCollision;
    bool colisionando;
    
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
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0f, 0f, 0f); // verticalInput);

        if (isGrounded == true) //mientras estes en el piso, se podra saltar, es para evitar volar
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                rb.AddForce(Vector3.up * jumpHeight);
                isGrounded = false;
                Debug.Log("Estas saltando");
            }
            //Debug.Log("Estas en el piso");
        }

        movement.Normalize();

        transform.Translate(movement * Time.deltaTime * speed); //para moverse segun el player
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("" + "Coin")) //("" + "Coin"))
        {
            Debug.Log("MONEDA RECOGIDA");
            Coins++;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (colisionando) return; //para asegurar que no colisione varias veces seguidas
            colisionando = true;

            //if (colisionando == true)
            OnEnemyCollision?.Invoke();
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        colisionando = false;
    }
}
