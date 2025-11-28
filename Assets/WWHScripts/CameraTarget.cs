using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public PlayerController controller;
   

    private void FixedUpdate()
    {
        Camera.main.transform.position = new Vector3(controller.transform.position.x , controller.transform.position.y , transform.position.z);
    }
}
