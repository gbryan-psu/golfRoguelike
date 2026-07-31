using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public sealed class CameraTestSwitcher : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Transform ballToFollow;

    private readonly InputAction toggleViewAction = new(
        name: "Toggle Camera",
        type: InputActionType.Button,
        binding: "<Keyboard>/space");

    private bool showingFlightView;

    private void OnEnable()
    {
        toggleViewAction.performed += ToggleView;
        toggleViewAction.Enable();
    }

    private void Start()
    {
        ShowHittingView();
    }

    private void LateUpdate()
    {
        if (showingFlightView && ballToFollow != null)
            cameraController.FollowBall(ballToFollow.position);
    }

    private void OnDisable()
    {
        toggleViewAction.performed -= ToggleView;
        toggleViewAction.Disable();
    }

    private void OnDestroy()
    {
        toggleViewAction.Dispose();
    }

    private void ToggleView(InputAction.CallbackContext _)
    {
        if (showingFlightView)
            ShowHittingView();
        else
            ShowFlightView();
    }

    private void ShowHittingView()
    {
        showingFlightView = false;
        cameraController.ShowHittingView();
    }

    private void ShowFlightView()
    {
        showingFlightView = true;
        cameraController.ShowFlightView();
    }
}
