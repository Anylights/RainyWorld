using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public Transform centerPoint;   // 圆心位置
    public float radius = 2f;       // 圆的半径
    public float speed = 2f;        // 运动速度
    public float initialAngle = 0f; // 初始角度

    private float angle;            // 当前角度

    void Start()
    {
        // 设置初始角度
        angle = initialAngle * Mathf.Deg2Rad; // 将初始角度从度数转换为弧度
    }

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
