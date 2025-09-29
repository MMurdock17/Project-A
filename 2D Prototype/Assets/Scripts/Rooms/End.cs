using UnityEngine;

public class End : MonoBehaviour
{
    //Display screen when player completes level
    public GameObject winUI;

    //Player collides with trophy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Stop game and show win screen
            Time.timeScale = 0;
            winUI.SetActive(true);
        }
    }
}
