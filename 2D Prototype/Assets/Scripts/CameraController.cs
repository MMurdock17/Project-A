using UnityEngine;

public class CameraController : MonoBehaviour
{
    
[SerializeField] private float speed;
private float positionX;
private Vector3 velocity = Vector3.zero;

private void Update()
{
    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(positionX, transform.position.y, transform.position.z),
    ref velocity, speed * Time.deltaTime);
}

public void NewRoom(Transform _newRoom)
{
    positionX = _newRoom.position.x;
}

}
