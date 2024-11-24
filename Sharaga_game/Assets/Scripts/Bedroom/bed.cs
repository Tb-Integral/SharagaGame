using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bed : MonoBehaviour
{
    [SerializeField] private GameObject img1;
    [SerializeField] private GameObject img2;

    public Image whiteimg; // ��������� ����� �����������
    public Image blackimg; // ��������� ������ �����������
    public float fadeDuration = 2f;

    private void Start()
    {
        // ���������� ������ ����������� ��������� ������������
        Color blackColor = blackimg.color;
        blackColor.a = 1f; // ��������� ������
        blackimg.color = blackColor;

        // ���������� ����� ����������� ��������� ����������
        Color whiteColor = whiteimg.color;
        whiteColor.a = 0f; // ��������� ����������
        whiteimg.color = whiteColor;

        // ��������� ��������� �� ������� � �����������
        StartCoroutine(FadeInBlack());
    }

    private IEnumerator FadeInBlack()
    {
        float timer = 0f;
        Color color = blackimg.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / fadeDuration); // ��������� ����� �� 1 �� 0
            blackimg.color = color;
            yield return null;
        }

        color.a = 0f; // ��������� ����������
        blackimg.color = color;
    }

    private IEnumerator FadeOutWhite()
    {
        float timer = 0f;
        Color color = whiteimg.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // ����������� ����� �� 0 �� 1
            whiteimg.color = color;
            yield return null;
        }

        color.a = 1f; // ��������� ����� �����
        whiteimg.color = color;

        // ������� � ��������� �����
        SceneManager.LoadScene("Main");
    }
}
