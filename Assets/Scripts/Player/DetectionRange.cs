using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DetectionRange : MonoBehaviour
{
    [SerializeField] Transform Origin;
    RaycastHit hit;
    public float hitRange;
    
    public void EnemyDetected()
    {
        if (Physics.Raycast(Origin.position, Origin.right, out hit, hitRange, this.gameObject.GetComponent<PlayerAttack>().Enemies_Layer)) //(hit.collider != null)
        {
            hit.collider.GetComponent<Enemies>()?.recibirDaņo();
            //GetComponent<PlayerAttack>().detected = true;
            Debug.Log("Enemigo Atcado");
        }
    }
}
