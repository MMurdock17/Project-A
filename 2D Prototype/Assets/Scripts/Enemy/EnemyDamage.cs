using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //Damage dealt to player
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //Player takes damage
        if (collision.tag == "Player")
            collision.GetComponent<Health>().TakeDamage(damage);
    }
}
