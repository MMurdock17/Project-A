using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	//Time between attacks, point of firing for the pineapples, array of pineapples, and sound played when used
   [SerializeField] private float attackCooldown;
   [SerializeField] private Transform firePoint;
   [SerializeField] private GameObject[] pineapples;
   [SerializeField] private AudioClip pineappleSound;

   //Animation, getting player movement script, tracking for cooldown
   private Animator anim;
   private PlayerMovement playerMovement;
   private float cooldownTimer = Mathf.Infinity;

   private void Awake()
   {
	   //References for animator and player movement components
	   anim = GetComponent<Animator>();
	   playerMovement = GetComponent<PlayerMovement>();
   }

   private void Update()
   {
	   //Projectile fired when correct button is pressed and cooldown has passed
	   if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
			Attack();
	   
		//Update cooldown timer
	   cooldownTimer += Time.deltaTime;
		
   }

   //Sound, animation, and firing
   private void Attack()
   {
	   SoundManager.instance.PlaySound(pineappleSound);

	   anim.SetTrigger("attack");
	   cooldownTimer = 0;

	   int pineappleIndex = FindPineapple();
	   GameObject pineapple = pineapples[pineappleIndex];

	   //Position and direction
	   pineapple.transform.position = firePoint.position;
	   pineapple.GetComponent<Pineapple>().SetDirection(Mathf.Sign(transform.localScale.x));

   }

   //Find pineapple in pool to use
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
