using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class perehodikLvl2 : MonoBehaviour
{
    [SerializeField] private GameObject Startdialog;
    [SerializeField] private Image fadeImage; // Привязать белое изображение
    [SerializeField] private float fadeDuration = 2f;

    private void Start()
    {
        //hero.enabled = false;
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        // Запускаем затухание
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / fadeDuration); // Уменьшаем альфа-канал от 1 до 0
            fadeImage.color = color;
            yield return null;
        }
        color.a = 0f; // Полностью прозрачный экран
        fadeImage.color = color;

        Startdialog.SetActive(true);
    }
}
