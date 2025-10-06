using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    //Player health and starting position
    private Health playerHealth;
    private Vector3 startPosition;
    private UIManager uiManager;

    private void Awake()
    {
        //Getting references
        playerHealth = GetComponent<Health>();
        startPosition = transform.position;
        uiManager = FindObjectOfType<UIManager>();
    }
    public void Respawn()
    {
        //Respawn at starting point
        uiManager.GameOver();
        transform.position = startPosition;

        //Camera to player's current room
    Camera.main.GetComponent<CameraController>().NewRoom(transform.parent);
    } 
}
