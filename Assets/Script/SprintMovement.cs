// using UnityEngine;

// public class SprintSystem : MonoBehaviour
// {
//     public float sprintDistance = 5f; // 冲刺距离
//     public float sprintCooldown = 2f; // 冷却时间

//     private bool canSprint = true; // 是否可以冲刺的标志
//     private Vector3 sprintDirection; // 冲刺方向
//     private float sprintStartTime; // 冲刺开始时间

//     void Update()
//     {
//         // 检测鼠标左键按下
//         if (Input.GetMouseButtonDown(0) && canSprint)
//         {
//             // 获取鼠标位置，并转换为世界坐标
//             Vector3 mousePosition = Input.mousePosition;
//             mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
//             mousePosition.z = 0f; // 因为我们是在2D环境下，所以z轴设为0

//             // 计算冲刺方向
//             sprintDirection = (mousePosition - transform.position).normalized;

//             // 启动冲刺
//             Sprint();
//         }

//         // 如果在冲刺中，持续移动
//         if (Time.time - sprintStartTime < sprintDistance)
//         {
//             transform.position += sprintDirection * Time.deltaTime * 10f; // 10f是移动速度，根据需要调整
//         }
//     }

//     void Sprint()
//     {
//         canSprint = false;
//         sprintStartTime = Time.time;
//         Invoke("ResetSprint", sprintCooldown);
//     }

//     void ResetSprint()
//     {
//         canSprint = true;
//     }
// }




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class SprintSystem : MonoBehaviour
// {
//     public Rigidbody2D rb;

//     [Header("Dash Settings")]
//     [SerializeField] float dashSpeed = 10f;
//     [SerializeField] float dashDuration = 1f;
//     [SerializeField] float dashCooldown = 1f;
//     bool isDashing;

//     void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.Space))
//         {
//             StartCoroutine(Dash());
//         }
//     }    

//     private IEnumerable Dash()
//     {
//         isDashing = true;
//         rb.velocity = new Vector2(MoveDirection.x * dashSpeed, MoveDirection.y * dashSpeed);
//         yield return new WaitForSeconds(dashDuration);    
//     }

// }





// using UnityEngine;

// public class SprintMovement : MonoBehaviour
// {
//     public float sprintSpeed = 10f; // 冲刺速度

//     private bool canSprint = true; // 是否可以冲刺的标志
//     private Vector3 sprintDirection; // 冲刺方向

//     void Update()
//     {
//         // 检测鼠标左键按下
//         if (Input.GetMouseButtonDown(0) && canSprint)
//         {
//             // 获取鼠标位置，并转换为世界坐标
//             Vector3 mousePosition = Input.mousePosition;
//             mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
//             mousePosition.z = 0f; // 因为我们是在2D环境下，所以z轴设为0

//             // 计算冲刺方向
//             sprintDirection = (mousePosition - transform.position).normalized;

//             // 启动冲刺
//             Sprint();
//         }

//         // 如果在冲刺中，持续移动
//         if (Input.GetMouseButton(0)) // 保持按住鼠标左键持续移动
//         {
//             transform.position += sprintDirection * sprintSpeed * Time.deltaTime;
//         }
//     }

//     void Sprint()
//     {
//         canSprint = false;
//         Invoke("ResetSprint", 2f); // 冲刺后的冷却时间为2秒
//     }

//     void ResetSprint()
//     {
//         canSprint = true;
//     }
// }





using UnityEngine;

public class SprintMovement : MonoBehaviour
{
    public float sprintSpeed = 10f; // 冲刺速度
    public float sprintDuration = 1f; // 冲刺持续时间
    public float sprintCooldown = 5f; // 冲刺冷却时间

    private bool canSprint = true; // 是否可以冲刺的标志
    private Vector3 sprintDirection; // 冲刺方向

    private float sprintTimer = 0f; // 计时器，用于计算冲刺持续时间

    void Update()
    {
        // 检测鼠标左键按下
        if (Input.GetMouseButtonDown(0) && canSprint)
        {
            // 获取鼠标位置，并转换为世界坐标
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0f; // 因为我们是在2D环境下，所以z轴设为0

            // 计算冲刺方向
            sprintDirection = (mousePosition - transform.position).normalized;

            // 启动冲刺
            StartSprint();
        }

        // 如果在冲刺中，持续移动
        if (sprintTimer > 0)
        {
            transform.position += sprintDirection * sprintSpeed * Time.deltaTime;
            sprintTimer -= Time.deltaTime;
        }
    }

    void StartSprint()
    {
        canSprint = false;
        sprintTimer = sprintDuration; // 设置冲刺持续时间
        Invoke("ResetSprint", sprintCooldown); // 冲刺后的冷却时间
    }

    void ResetSprint()
    {
        canSprint = true;
    }
}
