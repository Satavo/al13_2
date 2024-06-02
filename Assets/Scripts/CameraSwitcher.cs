using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject secondaryCamera;
    public float switchDelay = 2.0f; // Время задержки перед возвращением к основной камере
    public Material fadeMaterial;

    private bool switching = false;

    void Start()
    {
        // Убедитесь, что обе камеры включены
        mainCamera.SetActive(true);
        secondaryCamera.SetActive(false);
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
        while (timer < switchDelay)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / switchDelay);
            fadeMaterial.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // Переключение камер
        mainCamera.SetActive(false);
        secondaryCamera.SetActive(true);

        // Раззатемнение экрана
        timer = 0f;
        while (timer < switchDelay)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / switchDelay);
            fadeMaterial.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // Пауза перед возвращением к основной камере
        yield return new WaitForSeconds(switchDelay);

        // Затемнение экрана перед возвращением к основной камере
        timer = 0f;
        while (timer < switchDelay)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / switchDelay);
            fadeMaterial.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // Возвращение к основной камере
        mainCamera.SetActive(true);
        secondaryCamera.SetActive(false);

        // Раззатемнение экрана после возвращения к основной камере
        timer = 0f;
        while (timer < switchDelay)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / switchDelay);
            fadeMaterial.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        switching = false;
    }
}