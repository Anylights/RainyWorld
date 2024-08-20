using UnityEngine;

public class SatelliteMovement : MonoBehaviour
{
    public Transform centerPoint;   // 圆心位置
    public float radius = 2f;       // 圆的半径
    public float speed = 2f;        // 运动速度

    private float angle;            // 当前角度

    void Update()
    {
        // 计算物体在圆周运动中的位置
        angle += speed * Time.deltaTime;
        float x = centerPoint.position.x + radius * Mathf.Cos(angle);
        float y = centerPoint.position.y + radius * Mathf.Sin(angle);

        // 更新物体位置
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
