using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;
    private Camera fadeCamera; // Добавляем переменную для камеры

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }

    // Добавляем функцию для установки камеры
    public void SetFadeCamera(Camera camera)
    {
        fadeCamera = camera;
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while(timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            rend.material.SetColor("_Color", newColor);

            // Управляем прозрачностью камеры также
            if (fadeCamera != null)
            {
                fadeCamera.backgroundColor = newColor;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);

        if (fadeCamera != null)
        {
            fadeCamera.backgroundColor = newColor2;
        }
    }
}