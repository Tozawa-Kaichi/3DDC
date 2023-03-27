using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickFPSCamera : MonoBehaviour
{
    [SerializeField] FixedJoystick _joyStick;
    [SerializeField] float _cameraMoveSpeed;
    [SerializeField] float _limitAngleMaxUP;
    [SerializeField] float _limitAngleMinDown;

    Vector3 _cameraAngle;
    private void Update()
    {
        _cameraAngle =new(
            _joyStick.Horizontal * _cameraMoveSpeed,
            _joyStick.Vertical * _cameraMoveSpeed,
            0);

    }
    private void FixedUpdate()
    {
        transform.eulerAngles += new Vector3(
            Mathf.Clamp(_cameraAngle.y, _limitAngleMinDown, _limitAngleMaxUP) , _cameraAngle.x);
    }
    void RotateByJoystick()
    {

    }
}
