using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject objectPrefab;  // 要生成的物体预制体
    public float generationInterval = 5f;  // 生成物体的时间间隔
    public int minObjects = 1;  // 每次生成的最小物体数量
    public int maxObjects = 3;  // 每次生成的最大物体数量
    public float minDistanceFromPlayer = 2f;  // 生成物体与玩家之间的最小距离

    private Transform playerTransform;  // 玩家的 Transform 组件
    private float timer;  // 计时器

    void Start()
    {
        timer = generationInterval;  // 初始化计时器
        playerTransform = GameObject.FindGameObjectWithTag("spaceship").transform;  // 查找并存储玩家的 Transform 组件
    }

    void Update()
    {
        timer -= Time.deltaTime;  // 更新计时器

        if (timer <= 0)
        {
            GenerateObjects();  // 当计时器结束时，生成物体
            timer = generationInterval;  // 重置计时器
        }
    }

    void GenerateObjects()
    {
        int numObjects = Random.Range(minObjects, maxObjects + 1);  // 随机生成物体的数量

        for (int i = 0; i < numObjects; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle.normalized * Random.Range(minDistanceFromPlayer, minDistanceFromPlayer * 2);  // 生成位置的随机偏移，确保与玩家距离至少为 minDistanceFromPlayer
            Vector3 spawnPosition = (Vector2)playerTransform.position + randomOffset;

            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
