using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    //NOTA: por alguna razón desde el inspector se marca que ataca dos veces.
    //NOTA2: ahora parece que solo funciona siempre que no se spawnee un enemigo??

    public GameManager AttackEvent;
    //public int DetectionRange = 2;
    public LayerMask Enemies_Layer;
    public bool detected;
    private InputActionReference Attack_Input;
    //public Enemies Enemigo;
    GameObject Enemigo;

    //bool enemyIsNear;

    Renderer _renderer;
    Material Material;
    //particle system?
    //combo system ?

    void Start()
    {
        AttackEvent.AttackOnClick.AddListener(Attack); //cambiar x input system pq no parece estar funcionando bien con esto
    }

    // Update is called once per frame
    void Update()
    {
        _renderer = GetComponent<Renderer>();
        Material = GetComponent<Material>();
        Enemigo = GameObject.FindGameObjectWithTag("Enemy");

        //Material.mainTextureOffset = Vector3.zero;
        //_renderer.material.mainTexture.
    }

    public void Attack() //necesito q detecte a los enemigos y sus scripts
    {
        float distance = UnityEngine.Vector3.Distance(transform.position, Enemigo.transform.localPosition);
        if (detected == true) //distance < DetectionRange)//Enemigo.GetComponent<DetectionRange>()) //var distance = Vector3.Distance(objectOne, objectTwo); //agregar condicion para detectar distancia entre enemigo y player, si están cerca, se ejecuta esto
        {
            Debug.Log("Attacking");
            GetComponent<DetectionRange>().EnemyDetected();
            //Enemigo.GetComponent<Enemies>().recibirDaño(); // enemigo recibe daño apenas spawnea y el player hace click, capaz resolverlo con  booleano??
                                   //Enemigo.recibirDaño(1); // enemigo recibe daño apenas spawnea y el player hace click, capaz resolverlo con  booleano??
            detected = false;
        }

        //código de ataque c/ particle system
    }

    
    //void Attack2()
    //{
    //    Collider[] hitBox = Physics.OverlapSphere(ultimateHitBox.transform.position, ultimateRange, enemy);

    //    foreach (var box in hitBox)
    //    {
    //        box.GetComponent<EnemyController>().die();
    //    }
    //}



}
