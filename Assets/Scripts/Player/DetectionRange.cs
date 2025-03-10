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
            hit.collider.GetComponent<Enemies>()?.recibirDaño();
            //GetComponent<PlayerAttack>().detected = true;
            Debug.Log("Enemigo Atcado");
        }
    }
}
