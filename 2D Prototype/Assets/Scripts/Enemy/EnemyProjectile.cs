using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    //Info on projectile
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

    public void ActivateProjectile()
    {
        //Activates projectile and resets lifetime
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        //Move projectile
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    //Collision handling
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Damage player
        base.OnTriggerEnter2D(collision);

        //Deactivate on impact
        gameObject.SetActive(false);
    }

}
