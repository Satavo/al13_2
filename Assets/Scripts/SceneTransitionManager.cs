using System.Collections;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public Camera mainCamera;
    public Camera fadeCamera;

    private void Start()
    {
        fadeScreen.SetFadeCamera(fadeCamera);
    }

    public void SwitchCameraWithFade(Camera newCamera)
    {
        StartCoroutine(SwitchCameraWithFadeRoutine(newCamera));
    }

    IEnumerator SwitchCameraWithFadeRoutine(Camera newCamera)
    {
        fadeScreen.FadeOut(); // Запускаем затемнение

        yield return new WaitForSeconds(fadeScreen.fadeDuration); // Ждем завершения затемнения

        mainCamera.gameObject.SetActive(false); // Выключаем основную камеру

        fadeCamera.gameObject.SetActive(false); // Выключаем второстепенную камеру


        yield return new WaitForSeconds(1.0f); // Задержка перед включением основной камеры обратно

        fadeScreen.FadeIn(); // Запускаем осветление

        yield return new WaitForSeconds(fadeScreen.fadeDuration); // Ждем завершения осветления

        mainCamera.gameObject.SetActive(true); // Включаем основную камеру обратно
    }
}