using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class perehodik : MonoBehaviour
{
    [SerializeField] private GameObject dialog; //���� �������
    [SerializeField] private GameObject dialogEnd; //������ ���� �������
    [SerializeField] private Hero hero; // ��������� hero
    [SerializeField] private Image fadeImage; // ����� �����������
    [SerializeField] private float fadeDuration = 2f; //����� ��������

    private void Start()
    {
        // ��������� ������ ��������� ����� ��������� � �������� ��������
        if (Progress.Instance.first || Progress.Instance.lvl1_check && Progress.Instance.lvl2_check && Progress.Instance.lvl3_check)
        {
            hero.enabled = false;
        }
        // ������������� ��������� ����� ����� ��� ��������
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;


        // ��������� �������� � ����������
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / fadeDuration); // ��������� ������������ �� 1 �� 0
            fadeImage.color = color;
            yield return null;
        }
        color.a = 0f; // ������������ ������ ������ �� 0
        fadeImage.color = color;

        // ���� ����� ������� � ������� ������� ������ ���������
        if (Progress.Instance.first)
        {
            dialog.SetActive(true);
            Progress.Instance.first = false;
        }

        //���� ��� ����� �������� ������ �������� ������
        if (Progress.Instance.lvl1_check && Progress.Instance.lvl2_check && Progress.Instance.lvl3_check)
        {
            dialogEnd.SetActive(true);
        }
    }
}
