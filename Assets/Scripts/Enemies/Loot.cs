using UnityEngine;

public class Loot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            //Debug.Log("MONEDA RECOGIDA");
        }
    }
}
