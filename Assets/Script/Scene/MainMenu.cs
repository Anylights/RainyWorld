using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;
    public AudioSource BackGroundMusic;
    public GameObject RingPrefab;
    public GameObject Button; // 引用按钮的GameObject

    public CanvasGroup Heimu;

    private bool isBegin = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        if (!isBegin)
            StartCoroutine(PlayGameCoroutine());
    }

    private IEnumerator PlayGameCoroutine()
    {
        isBegin = true;
        // 播放音效
        audioSource.PlayOneShot(audioClip);

        // 获取按钮的位置并在该位置生成物体
        Vector3 buttonPosition = Button.transform.position;
        Instantiate(RingPrefab, buttonPosition, Quaternion.identity);

        // 计算音量减小的步长
        float initialVolume = audioSource.volume;
        float duration = 2f;
        float step = initialVolume / duration;

        // 在两秒内逐渐减小音量
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            BackGroundMusic.volume = Mathf.Lerp(initialVolume, 0, elapsedTime / duration);
            Heimu.alpha = Mathf.Lerp(0, 1, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保音量设置为零
        BackGroundMusic.volume = 0;

        // 切换到下一个场景
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
