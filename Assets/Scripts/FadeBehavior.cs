using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeBehavior : MonoBehaviour
{
    public Image fadeOverlay;
    public float fadeDuration = 1f;

    private float currentFadeProgress;

    public void FadeIn()
    {
        StartCoroutine(FadeToTarget(0f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeToTarget(1f));
    }

    private IEnumerator FadeToTarget(float targetAlpha)
    {
        float elapsedTime = 0f;
        float startingAlpha = fadeOverlay.color.a;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            currentFadeProgress = Mathf.Clamp01(elapsedTime / fadeDuration);

            Color currentColor = fadeOverlay.color;
            currentColor.a = Mathf.Lerp(startingAlpha, targetAlpha, currentFadeProgress);
            fadeOverlay.color = currentColor;

            yield return null;
        }

        currentFadeProgress = targetAlpha;
    }
}
