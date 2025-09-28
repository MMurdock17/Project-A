using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] private float attackCooldown;
   [SerializeField] private Transform firePoint;
   [SerializeField] private GameObject[] pineapples;
   [SerializeField] private AudioClip pineappleSound;

   private Animator anim;
   private PlayerMovement playerMovement;
   private float cooldownTimer = Mathf.Infinity;

   private void Awake()
   {
	   anim = GetComponent<Animator>();
	   playerMovement = GetComponent<PlayerMovement>();
   }

   private void Update()
   {
	   if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
			Attack();
	   
	   cooldownTimer += Time.deltaTime;
		
   }

   private void Attack()
   {
	   SoundManager.instance.PlaySound(pineappleSound);

	   anim.SetTrigger("attack");
	   cooldownTimer = 0;

	   int pineappleIndex = FindPineapple();
	   GameObject pineapple = pineapples[pineappleIndex];

	   pineapple.transform.position = firePoint.position;
	   pineapple.GetComponent<Pineapple>().SetDirection(Mathf.Sign(transform.localScale.x));

   }

   private int FindPineapple()
   {
	   for (int i = 0; i < pineapples.Length; i++)
	   {
		   if (!pineapples[i].activeInHierarchy)
			return i;
	   }
	   return 0;
   }

}
