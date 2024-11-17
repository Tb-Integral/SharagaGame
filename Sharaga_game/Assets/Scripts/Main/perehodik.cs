using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class perehodik : MonoBehaviour
{
    public Image fadeImage; // ��������� ����� �����������
    public float fadeDuration = 2f;

    private void Start()
    {
        // ������������� ��������� ���� (��������� �����)
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
    }
}
