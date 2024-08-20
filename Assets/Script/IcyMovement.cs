using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement = Vector2.zero;
    public float fSpeed = 5f;
    public float fMaxSpeed = 3f;
    public float fFriction = 3f;
    public float dashSpeedMultiplier = 3f; // 冲刺速度倍率
    public float dashDuration = 1f; // 冲刺时间
    public float dashCooldown = 2f; // 冲刺冷却时间

    private bool isDashing = false;
    private bool isCooldown = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // 获取Xbox控制器输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // 计算移动命令
        Vector2 movementOrder = movementDirection * fMaxSpeed;

        // 应用摩擦力
        if (movementDirection == Vector2.zero)
        {
            movement = Vector2.MoveTowards(movement, Vector2.zero, fFriction * Time.deltaTime);
        }

        // 限制移动速度
        movement = Vector2.ClampMagnitude(movement + movementOrder * fSpeed * Time.deltaTime, fMaxSpeed);

    }

    void Update()
    {
        // 检查空格键输入以进行冲刺
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && !isCooldown)
        {
            StartCoroutine(Dash());
        }

        // 应用移动到位置
        Vector2 newPosition = rb.position + movement * Time.deltaTime;
        rb.MovePosition(newPosition);
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        float originalMaxSpeed = fMaxSpeed;
        fMaxSpeed *= dashSpeedMultiplier;

        yield return new WaitForSeconds(dashDuration);

        fMaxSpeed = originalMaxSpeed;
        isDashing = false;

        // 开始冷却
        isCooldown = true;
        yield return new WaitForSeconds(dashCooldown);
        isCooldown = false;
    }
}
