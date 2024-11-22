using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject hero;

    public Image blackimg; // Привязать черное изображение
    public float fadeDuration = 2f;

    private SpriteRenderer spriteRenderer; // Для работы с цветом объекта

    void Start()
    {
        // Получаем SpriteRenderer объекта, на котором находится этот скрипт
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Установить черное изображение полностью непрозрачным
        Color blackColor = blackimg.color;
        blackColor.a = 1f; // Полностью черный
        blackimg.color = blackColor;

        // Запустить затухание от черного к прозрачному
        StartCoroutine(FadeInBlack());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == hero)
        {
            // Изменяем цвет объекта на более темный
            SetObjectColor(Color.gray);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Stay");
        if (collision.gameObject == hero && Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(FadeOutBlack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == hero)
        {
            // Возвращаем исходный цвет объекта
            SetObjectColor(Color.white);
        }
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

        color.a = 0f; // Полностью прозрачный
        blackimg.color = color;
    }

    private IEnumerator FadeOutBlack()
    {
        float timer = 0f;
        Color color = blackimg.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // Увеличиваем альфа от 0 до 1
            blackimg.color = color;
            yield return null;
        }

        color.a = 1f; // Полностью черный экран
        blackimg.color = color;

        // Переход к следующей сцене
        SceneManager.LoadScene("Main");
    }

    // Метод для установки цвета объекта
    private void SetObjectColor(Color color)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }
}