// //传送回主菜单

// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class LoadMainMenuOnDistance : MonoBehaviour
// {
//     public Transform player;        // 主角的 Transform
//     public Transform centerPoint;   // 圆形范围的中心点
//     public float triggerRadius;     // 触发跳转的圆形范围半径

//     private bool hasExited = false; // 是否已经触发跳转

//     void Update()
//     {
//         // 计算主角与圆形范围中心点之间的距离
//         float distanceToCenter = Vector3.Distance(player.position, centerPoint.position);

//         // 如果主角超过了设定的圆形范围半径且尚未跳转
//         if (distanceToCenter > triggerRadius && !hasExited)
//         {
//             // 标记为已经跳转，防止重复跳转
//             hasExited = true;

//             // 跳转到主菜单场景
//             SceneManager.LoadScene("Main Menu");
//         }
//     }
// }




//传送回出生点
using UnityEngine;

public class TeleportOnDistance : MonoBehaviour
{
    public Transform player;        // 主角的 Transform
    public Transform spawnPoint;    // 出生点的 Transform
    public float teleportRadius;    // 触发传送的圆形范围半径

    void Update()
    {
        // 计算主角与出生点之间的距离
        float distanceToSpawn = Vector3.Distance(player.position, spawnPoint.position);

        // 如果主角超过了设定的圆形范围半径
        if (distanceToSpawn > teleportRadius)
        {
            // 将主角传送到出生点
            player.position = spawnPoint.position;
        }
    }
}

