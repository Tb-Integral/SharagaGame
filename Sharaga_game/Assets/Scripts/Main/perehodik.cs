using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class perehodik : MonoBehaviour
{
    [SerializeField] private GameObject dialog; //окно диалога
    [SerializeField] private GameObject dialogEnd; //второе окно диалога
    [SerializeField] private Hero hero; // компонент hero
    [SerializeField] private Image fadeImage; // белое изображение
    [SerializeField] private float fadeDuration = 2f; //время перехода

    private void Start()
    {
        // запрещаем игроку двигаться перед стартовым и конечным диалогом
        if (Progress.Instance.first || Progress.Instance.lvl1_check && Progress.Instance.lvl2_check && Progress.Instance.lvl3_check)
        {
            hero.enabled = false;
        }
        // Устанавливаем полностью белый экран для перехода
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;


        // Запускаем корутину с затуханием
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / fadeDuration); // Уменьшаем прозрачность от 1 до 0
            fadeImage.color = color;
            yield return null;
        }
        color.a = 0f; // прозрачность белого экрана на 0
        fadeImage.color = color;

        // если игрок впервые в комнате врубаем диалог стартовый
        if (Progress.Instance.first)
        {
            dialog.SetActive(true);
            Progress.Instance.first = false;
        }

        //если все двери пройдены кидаем конечный диалог
        if (Progress.Instance.lvl1_check && Progress.Instance.lvl2_check && Progress.Instance.lvl3_check)
        {
            dialogEnd.SetActive(true);
        }
    }
}
