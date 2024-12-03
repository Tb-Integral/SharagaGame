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
            color.a = 1f - (timer / 1f); // ��������� �����-����� �� 1 �� 0
            gameObject.GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
        color.a = 0f; // ��������� ���������� �����
        gameObject.GetComponent<SpriteRenderer>().color = color;
        gameObject.SetActive(false);
    }
}
