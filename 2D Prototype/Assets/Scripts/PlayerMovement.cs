using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool grounded;
    private float move;
    private bool facingRight = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

private void Update()
{
    move = Input.GetAxisRaw("Horizontal");

    body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

    if (move > 0)
        sprite.flipX = false;
    else if (move < 0)
        sprite.flipX = true;

    if (Input.GetKey(KeyCode.Space) && grounded)
        Jump();

    anim.SetBool("run", move != 0);
    anim.SetBool("grounded", grounded);

}

private void Jump()
{
    body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
    anim.SetTrigger("jump");
    grounded = false;
}

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Ground")
        grounded = true;
}

public bool canAttack()
{
    return move == 0 && grounded;
}

}
