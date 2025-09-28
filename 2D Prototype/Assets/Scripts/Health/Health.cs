using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header ("Death Sound")]
    [SerializeField] private AudioClip deathSound;

    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

   /* public void Respawn()
    {
        dead = false;

    foreach (Behaviour component in components)
        component.enabled = true;

    GetComponent<PlayerMovement>().enabled = true;

    AddHealth(startingHealth);
    anim.ResetTrigger("die");
    anim.Play("Idle");
    } */

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;

                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;
                SoundManager.instance.PlaySound(deathSound);

                //Invoke(nameof(HandleRespawn), 2f);
            }
        }

    }
    /*private void HandleRespawn()
{
    GetComponent<PlayerRespawn>().Respawn();
}*/
}
