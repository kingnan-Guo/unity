using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // -----  参数变量 -----

    [Header("旋转速度")]
    public float xSpeed = 125.0f;
    public float ySpeed = 60.0f;

    [Header("缩放速度")]
    public float wheelSpeed = 50;

    [Header("移动速度")]
    public float xMoveSpeed = 200;
    public float yMoveSpeed = 200;

    [Header("是否无限制放大，但仍旧会受移动限制所规定的范围")]
    public bool isUnlimitedScale = true;

    [Header("镜头与中心点距离，在 isUnlimitedScale 变量为 true 时有效")]
    public float distance = 30;

    [Header("是否允许移动相机")]
    public bool isCameraMovementAllowed = true;

    [Header("是否允许旋转相机")]
    public bool isCameraRotationAllowed = true;

    [Header("是否允许缩放相机")]
    public bool isCameraZoomAllowed = true;

    [Header("是否开启位置限制")]
    public bool isPositionLimitEnabled = true;

    [Header("缩放限制，最大，最小")]
    public float maxZoom = 300;
    public float minZoom = 8;

    [Header("移动限制")]
    public float xMaxMove = 94;
    public float xMinMove = -94;
    public float yMaxMove = 58;
    public float yMinMove = 1;
    public float zMaxMove = 44;
    public float zMinMove = -44;

    // ----- 内部变量 -----

    private Transform tanks; // 中心点物体
    private Quaternion rotation; // 角度控制

    // ----- 公共方法 -----

    // 使相机跳转到模型
    public bool MoveToMod(string modName)
    {
        if (string.IsNullOrEmpty(modName))
            return false;

        Transform newTransform = GameObject.Find(modName)?.transform;

        if (newTransform != null)
        {
            tanks.position = newTransform.position;
            return true;
        }
        else
        {
            return false;
        }
    }

    // 使相机以指定速度围绕指定模型旋转一定角度
    public void CameraRotate(string modName, float xAngle, float yAngle, float zAngle, float velocity, bool follow)
    {
        MoveToMod(modName);

        // 设置旋转角度
        float targetX = transform.eulerAngles.x + xAngle;
        float targetY = transform.eulerAngles.y + yAngle;
        float targetZ = transform.eulerAngles.z + zAngle;

        // 开启协程执行动画
        StartCoroutine(AnimateCameraRotation(targetX, targetY, targetZ, velocity, follow));
    }

    // ----- 私有方法 -----

    // 协程，执行相机旋转动画
    private System.Collections.IEnumerator AnimateCameraRotation(float targetX, float targetY, float targetZ, float velocity, bool follow)
    {
        float animationSpeed = velocity;

        while (true)
        {
            float step = animationSpeed * Time.deltaTime;

            // 逐渐旋转至目标角度
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetX, targetY, targetZ), step);

            if (follow)
                tanks.rotation = transform.rotation;

            yield return null;
        }
    }

    // 更新相机的位置
    private void UpdateCameraPosition()
    {
        if (!isCameraMovementAllowed || !Input.GetMouseButton(2))
            return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 横向平移
        MoveCameraSideways(mouseX);

        // 纵向平移，若相机垂直地面则向前平移
        MoveCameraUpwards(mouseY);
    }

    // 更新相机的横向平移
    private void MoveCameraSideways(float mouseX)
    {
        transform.Translate(Vector3.right * xMoveSpeed * Time.deltaTime * -mouseX);
        tanks.Translate(Vector3.right * xMoveSpeed * Time.deltaTime * -mouseX);
    }

    // 更新相机的纵向平移
    private void MoveCameraUpwards(float mouseY)
    {
        transform.Translate(Vector3.up * yMoveSpeed * Time.deltaTime * -mouseY);
        tanks.Translate(Vector3.up * yMoveSpeed * Time.deltaTime * -mouseY);
    }

    // 更新相机的旋转
    private void UpdateCameraRotation()
    {
        if (!isCameraRotationAllowed || !Input.GetMouseButton(1))
            return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 设置横向旋转距离
        float x = transform.eulerAngles.x + mouseY * xSpeed * 0.02f;

        // 设置纵向旋转距离
        float y = transform.eulerAngles.y + mouseX * ySpeed * 0.02f;

        rotation = Quaternion.Euler(y, x, transform.eulerAngles.z);

        transform.rotation = rotation;
    }

    // 更新相机的缩放
    private void UpdateCameraZoom()
    {
        if (!isCameraZoomAllowed)
            return;

        if (isUnlimitedScale)
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

            // 方块与相机保持相应距离
            distance += scrollDelta * wheelSpeed;
        }
        else
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

            if ((scrollDelta < 0 || distance > minZoom) && (scrollDelta > 0 || distance < maxZoom) || !isPositionLimitEnabled)
            {
                distance += scrollDelta * wheelSpeed;
            }
        }

        rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        transform.position = rotation * new Vector3(0.0f, 0.0f, -distance) + tanks.position;
    }

    // ----- Unity 回调方法 -----

    private void Start()
    {
        tanks = transform; // 使用当前物体的 Transform，而不是寻找名为 "Main Camera" 的对象
    }

    private void Update()
    {
        UpdateCameraPosition();
        UpdateCameraRotation();
        UpdateCameraZoom();
    }
}

