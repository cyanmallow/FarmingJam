using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FadeInFadeOut : MonoBehaviour
{

    public float totalDuration = 3f;

    private TextMeshProUGUI text;
    private float halfDuration;
    public GameObject fadeInFadeOut;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        halfDuration = totalDuration / 2f;
    }

    void OnEnable()
    {
        StartCoroutine(FadeRoutine());
    }

    System.Collections.IEnumerator FadeRoutine()
    {
        Color color = text.color;

        // Fade In
        float t = 0f;
        while (t < halfDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / halfDuration);
            text.color = color;
            yield return null;
        }

        // Fade Out
        t = 0f;
        while (t < halfDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t / halfDuration);
            text.color = color;
            yield return null;
        }
        fadeInFadeOut.SetActive(false);
    }
}


