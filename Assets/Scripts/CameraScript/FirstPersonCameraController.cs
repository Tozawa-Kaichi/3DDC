using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float mouseSensitivity = 2f;

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // カメラの回転
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // プレイヤーの回転
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
