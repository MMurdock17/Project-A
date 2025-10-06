using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    //Info on enemy
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header ("Idle Behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header ("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        //Stop moving animation
        anim.SetBool("moving", false);
    }

    private void Update()
    {
        //Switching directions and turning once reaching edge
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
        
            else
            {
                DirectionChange();
            }
        }
    }

    //Direction change at edges
    private void DirectionChange()
    {
        idleTimer += Time.deltaTime;
        anim.SetBool("moving", false);
        
        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
    //Move enemy in direction
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        anim.SetBool("moving", true);

        //Flip based on direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
}
