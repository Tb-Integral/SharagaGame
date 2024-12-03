using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class perehodik : MonoBehaviour
{
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject dialogEnd;
    [SerializeField] private Hero hero;

    public Image fadeImage; // Привязать белое изображение
    public float fadeDuration = 2f;

    private void Start()
    {
        // Устанавливаем начальный цвет (полностью белый)
        if (Progress.Instance.first)
        {
            hero.enabled = false;
        }
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

        if (Progress.Instance.first)
        {
            dialog.SetActive(true);
            Progress.Instance.first = false;
        }

        if (Progress.Instance.lvl1_check && Progress.Instance.lvl2_check && Progress.Instance.lvl3_check)
        {
            dialogEnd.SetActive(true);
        }
    }
}
