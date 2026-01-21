using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; // Required for scene transitions

public class ScreenFader : MonoBehaviour
{
    public Image faderImage;
    public float fadeDuration; // Duration of the fade in seconds

    // Call this to fade to black
    public void FadeToBlack()
    {
        StartCoroutine(FadeRoutine(1f)); // Fade to an alpha of 1 (opaque)
        WaitForXSeconds(fadeDuration);

    }

    // Call this to fade in from black (make scene visible)
    public void FadeFromBlack()
    {
        StartCoroutine(FadeRoutine(0f)); // Fade to an alpha of 0 (transparent)
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        float startAlpha = faderImage.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            faderImage.color = new Color(faderImage.color.r, faderImage.color.g, faderImage.color.b, newAlpha);
            yield return null; // Wait for the next frame
        }
        faderImage.color = new Color(faderImage.color.r, faderImage.color.g, faderImage.color.b, targetAlpha);
    }

    // Example of a function to use for scene transitions
    public void FadeAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        yield return StartCoroutine(FadeRoutine(1f)); // Fade to black
        SceneManager.LoadScene(sceneName); // Load new scene
        // The new scene's fader should call FadeFromBlack() in its Start() method
    }

    private IEnumerator WaitForXSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
