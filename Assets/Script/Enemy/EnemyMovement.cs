


using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private GameObject target;  // 追踪的目标
    private float distance;
    // public AudioClip[] audioClips;  // 存放音频剪辑的数组

    // public AudioSource audioSource;
    public GameObject RingPrefab;

    void Start()
    {
        // 根据标签查找追踪目标
        target = GameObject.FindGameObjectWithTag("spaceship");
        if (target == null)
        {
            Debug.LogError("Cannot find target with tag 'spaceship'");
        }
    }

    void Update()
    {
        if (target != null)
        {
            distance = Vector2.Distance(transform.position, target.transform.position);
            Vector2 direction = (Vector2)(target.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 当碰撞器进入另一个碰撞器时被调用
        // 可以根据需要修改触发条件，比如只在特定标签的物体上触发消失
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Instantiate(RingPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // 销毁自身游戏对象
        }
    }
}
