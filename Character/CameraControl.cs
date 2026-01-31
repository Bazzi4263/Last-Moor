using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // xRotation 필드를 선언합니다.
    private float xRotation = 0f;

    public float sensitivity = 100f;

    public Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 마우스 입력으로 xRotation 값을 변경합니다.
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);

        // 카메라의 회전값을 설정합니다.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
