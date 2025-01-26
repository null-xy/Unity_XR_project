using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerPositionSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionReference switchButton;
    private Vector3 roomPosition = new Vector3(0, 0, 0);
    private Vector3 externalPosition = new Vector3(0, 0, -30);
    private bool isInRoom = true;

    void Start()
    {
        transform.position = roomPosition;
        switchButton.action.Enable();
    }
    void OnEnable()
    {
        if (switchButton != null)
            switchButton.action.Enable();
    }
    void OnDisable()
    {
        if (switchButton != null)
            switchButton.action.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        CheckPlayerPosition();
        if (switchButton.action.WasPressedThisFrame())
        {
            SwitchPosition();
        }
    }
    private void CheckPlayerPosition()
    {
        float playerX = transform.position.x;
        float playerZ = transform.position.z;

        if (playerX >= -7.5f && playerX <= 7.5f  && playerZ >= -7.5f && playerZ <= 7.5f)
        {
            isInRoom = true;
        }
        else
        {
            isInRoom = false;
        }
    }
    private void SwitchPosition()
    {
        if (isInRoom)
        {
            transform.position = externalPosition;
        }
        else
        {
            transform.position = roomPosition;
        }
        isInRoom = !isInRoom;
    }

}
