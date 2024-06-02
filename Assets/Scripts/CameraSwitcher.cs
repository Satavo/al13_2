using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;
    public float fadeDuration = 1.0f;
    public float switchDelay = 2.0f; // Время задержки перед возвращением к основной камере
    public Image fadeOverlay;

    private bool switching = false;

    void Start()
    {
        // Убедитесь, что обе камеры включены
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
    }

    public void SwitchCameras()
    {
        if (!switching)
        {
            StartCoroutine(SwitchCoroutine());
        }
    }

    IEnumerator SwitchCoroutine()
    {
        switching = true;

        // Затемнение экрана
        float timer = 0f;
        while (timer < fadeDuration)
        {
            fadeOverlay.color = Color.Lerp(Color.clear, Color.black, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Переключение камер
        mainCamera.enabled = !mainCamera.enabled;
        secondaryCamera.enabled = !secondaryCamera.enabled;

        // Раззатемнение экрана
        timer = 0f;
        while (timer < fadeDuration)
        {
            fadeOverlay.color = Color.Lerp(Color.black, Color.clear, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Задержка перед возвращением к основной камере
        yield return new WaitForSeconds(switchDelay);

        // Затемнение экрана перед возвращением к основной камере
        timer = 0f;
        while (timer < fadeDuration)
        {
            fadeOverlay.color = Color.Lerp(Color.clear, Color.black, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Возвращение к основной камере
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;

        // Раззатемнение экрана после возвращения к основной камере
        timer = 0f;
        while (timer < fadeDuration)
        {
            fadeOverlay.color = Color.Lerp(Color.black, Color.clear, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        switching = false;
    }
}