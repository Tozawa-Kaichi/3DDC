using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick _joyStick;
    [SerializeField] float _moveSpeed;
    [SerializeField] Rigidbody _rb;
    [SerializeField] Transform _cameraTransform;
    public float MoveSpeedMultiplier { get; set; } = 1f; // 移動速度倍率の初期値
    public float EffectiveMoveSpeed{get { return _moveSpeed * MoveSpeedMultiplier; }}
    float _h;
    float _v;
    [SerializeField] bool _useJoystick = true; // 操作タイプを切り替えるフラグ

    private void Update()
    {
        if (_useJoystick)
        {
            HandleJoystickInput();
        }
        else
        {
            HandleKeyboardInput();
        }
    }

    private void HandleJoystickInput()
    {
        _h = _joyStick.Horizontal;
        _v = _joyStick.Vertical;
    }

    private void HandleKeyboardInput()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(_cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = (_h * _cameraTransform.right + _v * cameraForward).normalized;
        Vector3 velocity = moveDirection * _moveSpeed;

        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
    }
    private void OnDisable()
    {
        // 移動停止
        _rb.velocity = Vector3.zero;
    }
    public void ToggleUseJoystick(bool value)
    {
        _useJoystick = value;
    }
}
