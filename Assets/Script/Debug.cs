using UnityEngine;

public class ApplyForceOnKeyPress : MonoBehaviour
{
    public KeyCode key = KeyCode.Space; // 触发施力的按键，默认为空格键
    public float forceMagnitude = 100f; // 施加的力的大小，这里是100单位

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            // 施加力到物体的刚体上
            rb.AddForce(new Vector2(forceMagnitude, 0f));
        }
    }
}