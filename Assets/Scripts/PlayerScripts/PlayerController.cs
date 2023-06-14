using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Playerの動きを制御するコンポーネント
/// スマホ移動に対応し3D対応にする
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick _joyStick;
    [SerializeField] float _moveSpeed;
    [SerializeField] Rigidbody _rb;
    float _h;
    float _v;
    private void Update()
    {
        _h = _joyStick.Horizontal;
        _v = _joyStick.Vertical;
    }
    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(_h, 0, _v).normalized * _moveSpeed;
        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
    }
}
