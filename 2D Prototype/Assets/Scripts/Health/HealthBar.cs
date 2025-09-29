using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Looking at health script and adding images for health bar
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currentHealth;

    private void Start()
    {
        //Initialize max health
        totalHealth.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        //Fill health bar to player's current health
        currentHealth.fillAmount = playerHealth.currentHealth / 10;
    }

}
