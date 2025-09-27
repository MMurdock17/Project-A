using UnityEngine;

public class Door : MonoBehaviour
{
    
[SerializeField] private Transform lastRoom;
[SerializeField] private Transform nextRoom;
[SerializeField] private CameraController camera;

private void Awake()
{
        camera = Camera.main.GetComponent<CameraController>();
}

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Player")
    {
        if (collision.transform.position.x < transform.position.x)
            camera.NewRoom(nextRoom);
        else
            camera.NewRoom(lastRoom);
    }
}

}
