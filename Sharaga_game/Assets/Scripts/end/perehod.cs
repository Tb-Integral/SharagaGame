using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class perehod : MonoBehaviour
{
    [SerializeField] private Image black;
    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private GameObject dialog;

    private void Start()
    {
        StartCoroutine(BlackIn());
    }

    private IEnumerator BlackIn()
    {
        float timer = 0f;
        Color color = black.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / fadeDuration); // Уменьшаем альфа-канал от 1 до 0
            black.color = color;
            yield return null;
        }
        color.a = 0f; // Полностью прозрачный экран
        black.color = color;

        dialog.SetActive(true);
    }
}
