using UnityEngine;

public class Door : MonoBehaviour
{
    //Previous room, next room, camera controller
[SerializeField] private Transform lastRoom;
[SerializeField] private Transform nextRoom;
[SerializeField] private CameraController camera;

private void Awake()
{
    //Get camera component
        camera = Camera.main.GetComponent<CameraController>();
}

//Player collides with door
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Player")
    {
        //Switch room for camera depending on what room the player is in
        if (collision.transform.position.x < transform.position.x)
            camera.NewRoom(nextRoom);
        else
            camera.NewRoom(lastRoom);
    }
}

}
