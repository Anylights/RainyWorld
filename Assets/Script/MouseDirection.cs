using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // 移动速度
    public float smoothingFactor = 0.1f; // 略微滑行的平滑因子

    private Vector3 targetPosition;     // 目标位置

    void Update()
    {
        // 获取鼠标在世界坐标下的位置
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // 确保z轴位置一致

        // 设置角色朝向鼠标位置
        transform.up = (mousePosition - transform.position).normalized;

        // 计算目标位置（略微滑行）
        targetPosition = Vector3.Lerp(transform.position, mousePosition, smoothingFactor);

        // 使用SmoothDamp将当前位置平滑过渡到目标位置
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothingFactor / moveSpeed);
    }

    private Vector3 velocity = Vector3.zero; // 平滑速度参考
}