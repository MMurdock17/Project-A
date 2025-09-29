using UnityEngine;

public class CameraController : MonoBehaviour
{

//Camera speed
[SerializeField] private float speed;

//Moving to position
private float positionX;

//Smooth movement
private Vector3 velocity = Vector3.zero;

private void Update()
{
    //Move camera towards X
    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(positionX, transform.position.y, transform.position.z), ref velocity, speed);
}

public void NewRoom(Transform _newRoom)
{
    //Updates X position when in new room
    positionX = _newRoom.position.x;
}

}
