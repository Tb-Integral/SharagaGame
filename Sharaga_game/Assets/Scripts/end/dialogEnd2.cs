using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class dialogEnd2 : MonoBehaviour
{
    [SerializeField] private Image black;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color color = black.color;

        while (timer < 2f)
        {
            timer += Time.deltaTime;
            color.a = timer / 2f; // Уменьшаем альфа-канал от 1 до 0
            black.color = color;
            yield return null;
        }
        color.a = 1f; // Полностью прозрачный экран
        black.color = color;
        SceneManager.LoadScene("Menu");
    }
}
