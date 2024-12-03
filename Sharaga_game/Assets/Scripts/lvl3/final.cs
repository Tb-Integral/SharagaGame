using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class final : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 2f;
    GameObject progress;
    Progress _progress;

    private void Start()
    {
        progress = GameObject.Find("progress manager");
        _progress = progress.GetComponent<Progress>();
        StartCoroutine(FadeIn());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        _progress.lvl3_check = true;
        _progress.first = false;
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }
        color.a = 1f;
        fadeImage.color = color;

        SceneManager.LoadScene("Main");
    }

    private IEnumerator FadeIn()
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
    }
}
