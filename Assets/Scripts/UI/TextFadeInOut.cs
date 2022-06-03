using System.Collections;
using TMPro;
using UnityEngine;

public class TextFadeInOut : MonoBehaviour
{
    [Range(0.1f, 5.0f)]
    public float fadeInTime = 3.0f;
    [Range(0.1f, 5.0f)]
    public float fadeOutTime = 3.0f;

    private TMP_Text text;

    public void Awake()
    {
        text = GetComponent<TMP_Text>();

        // start with text faded out
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeTextToFullAlpha(fadeInTime));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeTextToZeroAlpha(fadeOutTime));
    }

    public IEnumerator FadeTextToFullAlpha(float t)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
