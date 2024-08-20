using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour
{
    public CanvasGroup HeiMu;
    private float fadeDuration = 2.0f;

    void Start()
    {
        // Start the coroutine to handle the sequence of events
        StartCoroutine(TransitionSequence());
    }

    IEnumerator TransitionSequence()
    {
        // Wait for 19 seconds
        yield return new WaitForSeconds(17.0f);

        // Fade in HeiMu over 2 seconds
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            HeiMu.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        HeiMu.alpha = 1.0f;

        // Wait for an additional 2 seconds
        yield return new WaitForSeconds(2.0f);

        // Load the Main Menu scene
        SceneManager.LoadScene("Main Menu");
    }
}
