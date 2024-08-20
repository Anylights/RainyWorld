using UnityEngine;

public class OnHitFunctionDestroy : MonoBehaviour

{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查碰撞对象是否为名为 "spaceship" 的物体
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Hit applied");
            // 销毁当前物体的父级对象
            Destroy(transform.parent.gameObject);
        }
    }
}
