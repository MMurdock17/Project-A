using UnityEngine;

public class Pineapple : MonoBehaviour
{
 
//Projectile speed, direction, impact
[SerializeField] private float speed = 10f;
private float direction;
private bool hit;
private float lifetime;

//Impact animation and detection
private Animator anim;
private BoxCollider2D boxCollider;

private void Awake()
{
	//Getting references
	anim = GetComponent<Animator>();
	boxCollider = GetComponent<BoxCollider2D>();
}

private void Update()
{
	//Stopping movement on impact
	if (hit) return;

	//Move in specified direction
	float movementSpeed = speed * Time.deltaTime * direction;
	transform.Translate(movementSpeed, 0, 0);

	lifetime += Time.deltaTime;
	if (lifetime > 5) gameObject.SetActive(false);
}

//Collision handling
private void OnTriggerEnter2D(Collider2D collision)
{
	//Ignore self-collision
	if (collision.gameObject == this.gameObject) return;

	hit = true;
	boxCollider.enabled = false;
	anim.SetTrigger("Impact");
}

public void SetDirection(float _direction)
{
	lifetime = 0;
	direction = _direction;
	gameObject.SetActive(true);
	hit = false;
	boxCollider.enabled = true;

	//Flip sprite based on direction
	float localScaleX = transform.localScale.x;
	if (Mathf.Sign(localScaleX) != _direction)
		localScaleX = -localScaleX;

		transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

		//Deactivate on impact
}
private void Deactivate()
{
	gameObject.SetActive(false);
}

}
