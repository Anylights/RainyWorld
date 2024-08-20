using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAnimation : MonoBehaviour
{
    // public GameObject track;
    // public int trackNumber = 10;
    // float trackTime;
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     Instantiate(track, transform.position, Quaternion.identity);sbyte
    //     trackTime = 0.5f;
    // }


    public GameObject imagePrefab; // 图片的预制体
    public float interval = 0.2f;  // 生成间隔时间
    private float timer;  
             // 计时器
    private void Start()
    {
        timer = interval; // 初始化计时器
    }

    private void Update()
    {
        timer -= Time.deltaTime; // 更新计时器

        if (timer <= 0f)
        {
            SpawnImage();      // 调用生成图片的方法
            timer = interval;  // 重置计时器
        }
    }

        private void SpawnImage()
        {
        // 在当前物体的位置生成图片预制体
        Instantiate(imagePrefab, transform.position, Quaternion.identity);
        }
}


