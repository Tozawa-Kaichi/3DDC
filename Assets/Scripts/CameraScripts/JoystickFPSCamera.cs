using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickFPSCamera : MonoBehaviour
{
    [SerializeField] FixedJoystick _joyStick;
    [SerializeField] float _cameraMoveSpeed;
    private void Update()
    {
        Vector3 cameraAngle =new Vector3(
            _joyStick.Horizontal * _cameraMoveSpeed,
            _joyStick.Vertical * _cameraMoveSpeed,
            0);
    }
    private void FixedUpdate()
    {
        
    }
    void RotateByJoystick()
    {

    }
}
