using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public AudioClip[] audioClips;  // 存放音频剪辑的数组

    private AudioSource audioSource;
    public GameObject RingPrefab;
    public CanvasGroup HeiMuCanvasGroup; // HeiMu Canvas Group

    public AudioSource BackMusic;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {

        // Ensure health doesn't exceed numOfHearts
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        // Update heart sprites based on current health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Enable or disable hearts based on numOfHearts
            hearts[i].enabled = i < numOfHearts;
        }

        if (health <= 0)
        {
            Debug.Log("Player has run out of health. Loading main menu.");
            StartCoroutine(ShowHeiMuAndReload());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Example: Decrease health when colliding with objects tagged as "Enemy" or "EnemySpaceship"
        if ((collision.gameObject.CompareTag("Enemy")) || collision.gameObject.CompareTag("Invisible"))
        {
            Debug.Log("Collided with Enemy or EnemySpaceship");
            health--; // Decrease health

            int randomIndex = Random.Range(0, audioClips.Length);
            AudioClip randomClip = audioClips[randomIndex];
            audioSource.PlayOneShot(randomClip);
            Instantiate(RingPrefab, transform.position, Quaternion.identity);
        }
    }

    IEnumerator ShowHeiMuAndReload()
    {
        float duration = 1.0f;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            HeiMuCanvasGroup.alpha = Mathf.Lerp(0, 1, elapsed / duration);
            BackMusic.volume = Mathf.Lerp(1, 0, elapsed / duration);
            yield return null;
        }

        yield return new WaitForSeconds(0.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
