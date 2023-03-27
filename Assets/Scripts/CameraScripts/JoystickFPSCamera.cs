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
        Vector3 angle =new(
            _joyStick.Horizontal * _cameraMoveSpeed,
            _joyStick.Vertical * _cameraMoveSpeed,
            0);
        _cameraAngle += new Vector3(-angle.y, angle.x);
        Mathf.Clamp(transform.eulerAngles.x, _limitAngleMinDown, _limitAngleMaxUP);
        transform.eulerAngles = _cameraAngle;
        
    }
    private void FixedUpdate()
    {

        
    }
    void RotateByJoystick()
    {

    }
}
