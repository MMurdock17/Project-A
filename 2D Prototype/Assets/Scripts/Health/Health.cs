using UnityEngine;

public class Health : MonoBehaviour
{
    //Tracks starting and current health, animation, and singular death
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header ("Death Sound")]
    [SerializeField] private AudioClip deathSound;

    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        //Get max health for starting
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void AddHealth(float _value)
    {
        //Give health back to player
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //Play hurt animation
            anim.SetTrigger("hurt");
        }
        else
        {
            //Disable player movements and other related components
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;

                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;

                //Call game over screen
                Invoke(nameof(GameOver), 1f);
            }
        }

    }
    //Calling game over
    private void GameOver()
{
    FindObjectOfType<UIManager>().GameOver();
}
    
}
