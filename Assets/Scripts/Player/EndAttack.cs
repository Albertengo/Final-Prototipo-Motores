using UnityEngine;

public class EndAttack : MonoBehaviour
{
    static public bool Attacking;
    public void end_Attack()
    {
        Attacking = false;
    }
}
