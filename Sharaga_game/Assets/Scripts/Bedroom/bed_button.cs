using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bed_button : MonoBehaviour
{

    [SerializeField] private GameObject img1;
    [SerializeField] private GameObject img2;
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject dialog;

    public Image whiteimg; // Привязать белое изображение
    public Image blackimg; // Привязать черное изображение
    public float fadeDuration = 2f;

    private Image targetImage;

    void Start()
    {
        targetImage = GetComponent<Image>();

        // Установить черное изображение полностью непрозрачным
        Color blackColor = blackimg.color;
        blackColor.a = 1f; // Полностью черный
        blackimg.color = blackColor;

        // Установить белое изображение полностью прозрачным
        Color whiteColor = whiteimg.color;
        whiteColor.a = 0f; // Полностью прозрачное
        whiteimg.color = whiteColor;

        // Запустить затухание от черного к прозрачному
        StartCoroutine(FadeInBlack());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Color newColor = targetImage.color;
        newColor.a = 1f;
        targetImage.color = newColor;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Stay");
        if (Input.GetKey(KeyCode.Space))
        {
            hero.SetActive(false);
            img2.SetActive(true);
            img1.SetActive(false);

            // Начать затухание белого изображения
            StartCoroutine(FadeOutWhite());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Color newColor = targetImage.color;
        newColor.a = 0f;
        targetImage.color = newColor;
    }

    private IEnumerator FadeInBlack()
    {
        float timer = 0f;
        Color color = blackimg.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / fadeDuration); // Уменьшаем альфа от 1 до 0
            blackimg.color = color;
            yield return null;
        }
        dialog.SetActive(true);

        color.a = 0f; // Полностью прозрачный
        blackimg.color = color;
    }

    private IEnumerator FadeOutWhite()
    {

        yield return new WaitForSeconds(2f);
        float timer = 0f;
        Color color = whiteimg.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // Увеличиваем альфа от 0 до 1
            whiteimg.color = color;
            yield return null;
        }

        color.a = 1f; // Полностью белый экран
        whiteimg.color = color;

        // Переход к следующей сцене
        SceneManager.LoadScene("Main");
    }
}
