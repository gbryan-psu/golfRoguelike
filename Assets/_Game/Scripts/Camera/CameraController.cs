using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera hittingCamera;
    [SerializeField] private Camera flightCamera;

    [SerializeField] private float followSpeed = 5f;

    public void ShowHittingView()
    {
        hittingCamera.enabled = true;
        flightCamera.enabled = false;
    }
    public void ShowFlightView()
    {
        hittingCamera.enabled = false;
        flightCamera.enabled = true;
    }

    public void FollowBall(Vector3 ballPosition)
    {
        Vector3 targetPosition = new Vector3(
          ballPosition.x,
          ballPosition.y,
          flightCamera.transform.position.z  
        );

        flightCamera.transform.position = Vector3.Lerp(
            flightCamera.transform.position,
            targetPosition,
            Time.deltaTime * followSpeed
        );
    }
}
