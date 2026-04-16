using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class BuildingControls : MonoBehaviour
{
    //Inputs
    [SerializeField] private PlayerInput playerInput;
    private InputAction enableCameraAction;

    [SerializeField] private CinemachineInputAxisController cameraRotationController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enableCameraAction = playerInput.actions.FindAction("BuildRotateCamEnable");

        if (playerInput.currentControlScheme == "Keyboard&Mouse") //If keyborad & mouse
        {
            enableCameraAction.started += EnableLookMovement;
            enableCameraAction.canceled += DisableLookMovement;
            cameraRotationController.enabled = false;
        } else 
        {
            cameraRotationController.enabled = true;
        }
        Debug.Log("started");
    }

    private void EnableLookMovement(InputAction.CallbackContext ctx) 
    {
        Debug.Log("started");
        cameraRotationController.enabled = true;
    }

    private void DisableLookMovement(InputAction.CallbackContext ctx) 
    {
        cameraRotationController.enabled = false;
    }
}
