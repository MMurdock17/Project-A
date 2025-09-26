using UnityEngine;

public class Pineapple : MonoBehaviour
{
 

[SerializeField] private float speed;
private float direction;
private bool hit;

private Animator anim;
private BoxCollider2D boxCollider;

private void Awake()
{
	anim = GetComponent<Animator>();
	boxCollider = GetComponent<BoxCollider2D>();
}

private void Update()
{
	if (hit) return;
	float movementSpeed = speed * Time.deltaTime * direction;
	transform.Translate(movementSpeed, 0, 0);
}

private void OnTriggerEnter2D(Collider2D collision)
{
	if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
    {
	
	hit = true;
	boxCollider.enabled = false;
	anim.SetTrigger("Impact");
	}
}

public void SetDirection(float _direction)
{
	direction = _direction;
	gameObject.SetActive(true);
	hit = false;
	boxCollider.enabled = true;
}

private void Deactivate()
{
	gameObject.SetActive(false);
}

}
