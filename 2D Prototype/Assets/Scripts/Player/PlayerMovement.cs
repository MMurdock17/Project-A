using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player speed
    [SerializeField] private float speed;

    //Render sprite, components, get direction
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool grounded;
    private float move;
    private bool facingRight = true;

    //Jump sound effect
    [Header ("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        //Getting references
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

private void Update()
{
    //Get input
    move = Input.GetAxisRaw("Horizontal");

    body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

    //Flip sprite depending on direction
    if (move > 0)
        sprite.flipX = false;
    else if (move < 0)
        sprite.flipX = true;

        //Jump if space pressed
    if (Input.GetKey(KeyCode.Space) && grounded)
        Jump();

        //animation parameters
    anim.SetBool("run", move != 0);
    anim.SetBool("grounded", grounded);

}

private void Jump()
{
    //Sound effect, jump velocity, animation, checking if grounded
    SoundManager.instance.PlaySound(jumpSound);
    body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
    anim.SetTrigger("jump");
    grounded = false;
}

//Checking for collisions with ground
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Ground")
        grounded = true;
}

//Player can only attack when grounded
public bool canAttack()
{
    return move == 0 && grounded;
}

}
