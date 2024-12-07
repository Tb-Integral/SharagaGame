using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class perehodikLvl2 : MonoBehaviour
{
    [SerializeField] private GameObject Startdialog;
    [SerializeField] private Image fadeImage; // ��������� ����� �����������
    [SerializeField] private float fadeDuration = 2f;

    private void Start()
    {
        //hero.enabled = false;
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        // ��������� ���������
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / fadeDuration); // ��������� �����-����� �� 1 �� 0
            fadeImage.color = color;
            yield return null;
        }
        color.a = 0f; // ��������� ���������� �����
        fadeImage.color = color;

        Startdialog.SetActive(true);
    }
}
