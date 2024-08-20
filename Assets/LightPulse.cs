using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 确保你导入了URP命名空间

public class LightPulse : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D; // 引用2D光源
    public float minInnerRadius = 0.5f; // 最小内半径
    public float maxInnerRadius = 1.0f; // 最大内半径
    public float minOuterRadius = 1.0f; // 最小外半径
    public float maxOuterRadius = 2.0f; // 最大外半径
    public float pulseDuration = 2.0f; // 一个周期的时间

    private float timer = 0.0f;

    void Update()
    {
        // 计算时间
        timer += Time.deltaTime;
        float t = Mathf.PingPong(timer / pulseDuration, 1.0f);

        // 线性插值计算内外半径
        light2D.pointLightInnerRadius = Mathf.Lerp(minInnerRadius, maxInnerRadius, t);
        light2D.pointLightOuterRadius = Mathf.Lerp(minOuterRadius, maxOuterRadius, t);
    }
}
