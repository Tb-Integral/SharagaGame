using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dis : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Dis());
    }

    private IEnumerator Dis()
    {
        float timer = 0f;
        Color color = gameObject.GetComponent<SpriteRenderer>().color;

        while (timer < 1f)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / 1f); // Уменьшаем альфа-канал от 1 до 0
            gameObject.GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
        color.a = 0f; // Полностью прозрачный экран
        gameObject.GetComponent<SpriteRenderer>().color = color;
        gameObject.SetActive(false);
    }
}
