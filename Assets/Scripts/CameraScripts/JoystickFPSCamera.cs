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
        RotateByJoystick();
        if(_cameraAngle.x >= _limitAngleMaxUP)
        {
            _cameraAngle.x = _limitAngleMaxUP;
        }
        else if(_cameraAngle.x <= _limitAngleMinDown)
        {
            _cameraAngle.x = _limitAngleMinDown;
        }



    }
    private void FixedUpdate()
    {
        

    }
    void RotateByJoystick()
    {
        Vector3 angle = new(
            _joyStick.Horizontal * _cameraMoveSpeed,
            -_joyStick.Vertical * _cameraMoveSpeed,
            0);
        _cameraAngle += new Vector3(angle.y, angle.x);
        transform.eulerAngles = new Vector3(Mathf.Repeat(_cameraAngle.x,360),_cameraAngle.y);
    }
}
