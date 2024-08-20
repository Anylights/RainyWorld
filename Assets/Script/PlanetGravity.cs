// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlanetGravity : MonoBehaviour
// {
//     public GameObject Player;
//     Rigidbody2D rb;
//     public float gravityForce;
//     public float gravityDistance;

//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = Player.GetComponent<Rigidbody2D>();
//     }

//     // Update is called once per frame
//     void FixedUpdate()
//     {
//         float dist = Vector2.Distance(Player.transform.position,gameObject.transform.position);
//         if (dist < gravityDistance)
//         {
//         Vector2 v = transform.position -Player.transform.position ;
//         rb.AddForce(v.normalized*(1.0f - dist / gravityDistance)*gravityForce * 20);
//         }
//     }
// }




// using UnityEngine;

// public class PlanetGravity : MonoBehaviour
// {
//     public Transform spaceship; // 飞船的 Transform 组件
//     public float gravityConstant = 5f; // 引力常数，可以根据需要调整
//     public float maxGravityDistance = 10f; // 引力的最大影响距离

//     private Rigidbody2D spaceshipRigidbody;

//     void Start()
//     {
//         spaceshipRigidbody = spaceship.GetComponent<Rigidbody2D>();
//     }

//     void FixedUpdate()
//     {
//         Vector2 direction = transform.position - spaceship.position;
//         float distance = direction.magnitude;

//         if (distance > 0 && distance < maxGravityDistance)
//         {
//             // 计算引力大小
//             float gravityMagnitude = gravityConstant * (GetComponent<Rigidbody2D>().mass * spaceshipRigidbody.mass) / Mathf.Pow(distance, 1);

//             // 应用引力到飞船上
//             Vector2 gravityForce = direction.normalized * gravityMagnitude;
//             spaceshipRigidbody.AddForce(gravityForce);
//         }
//     }
// }

using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public float gravityConstant = 5f; // 引力常数，可以根据需要调整
    public float maxGravityDistance = 10f; // 引力的最大影响距离

    void FixedUpdate()
    {
        // 找到所有标记为 "spaceship" 和 "EnemySpaceship" 的游戏对象
        GameObject[] spaceships = GameObject.FindGameObjectsWithTag("spaceship");
        GameObject[] enemySpaceships = GameObject.FindGameObjectsWithTag("Enemy");

        // 对于 "spaceship" 类型的飞船，施加引力
        foreach (GameObject spaceship in spaceships)
        {
            ApplyGravity(spaceship);
        }

        // 对于 "EnemySpaceship" 类型的敌方飞船，施加引力
        foreach (GameObject enemySpaceship in enemySpaceships)
        {
            ApplyGravity(enemySpaceship);
        }
    }

    void ApplyGravity(GameObject obj)
    {
        Vector2 direction = transform.position - obj.transform.position;
        float distance = direction.magnitude;

        if (distance > 0 && distance < maxGravityDistance)
        {
            // 计算引力大小
            float gravityMagnitude = gravityConstant * (GetComponent<Rigidbody2D>().mass * obj.GetComponent<Rigidbody2D>().mass) / Mathf.Pow(distance, 2);

            // 应用引力到物体上
            Vector2 gravityForce = direction.normalized * gravityMagnitude;
            obj.GetComponent<Rigidbody2D>().AddForce(gravityForce);
        }
    }
}