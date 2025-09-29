using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Info for enemy
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header ("Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] pineapples;

    [Header ("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();

        //check for collider reference
        if (boxCollider == null)
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Check if player is in range
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }
        //No patrol while attacking
        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    //Launch projectile
    private void Attack()
    {
        cooldownTimer = 0;
        pineapples[FindPineapple()].transform.position = firepoint.position;
        pineapples[FindPineapple()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    //Find pineapple to use
    private int FindPineapple()
    {
        for (int i = 0; i < pineapples.Length; i++)
        {
            if (!pineapples[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    //Debugging for Gizmos
    private void OnDrawGizmos()
    {

        if (boxCollider == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

}
