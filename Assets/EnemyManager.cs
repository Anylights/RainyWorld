using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public AudioClip[] audioClips;  // 敌人被销毁时播放的音效
    private AudioSource audioSource;
    private int previousEnemyCount;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        previousEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void Update()
    {
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (currentEnemyCount < previousEnemyCount)
        {
            PlayEnemyDestroyedSound();
        }

        previousEnemyCount = currentEnemyCount;
    }

    void PlayEnemyDestroyedSound()
    {
        if (audioClips != null)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            AudioClip randomClip = audioClips[randomIndex];
            audioSource.PlayOneShot(randomClip);
        }
    }
}
