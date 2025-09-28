using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Health playerHealth;
    private Vector3 startPosition;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        startPosition = transform.position;
        uiManager = FindObjectOfType<UIManager>();
    }
    public void Respawn()
    {
        uiManager.GameOver();
        transform.position = startPosition;


    Camera.main.GetComponent<CameraController>().NewRoom(transform.parent);
    } 
}
