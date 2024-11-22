using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject hero;

    public Image blackimg; // ��������� ������ �����������
    public float fadeDuration = 2f;

    private SpriteRenderer spriteRenderer; // ��� ������ � ������ �������

    void Start()
    {
        // �������� SpriteRenderer �������, �� ������� ��������� ���� ������
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ���������� ������ ����������� ��������� ������������
        Color blackColor = blackimg.color;
        blackColor.a = 1f; // ��������� ������
        blackimg.color = blackColor;

        // ��������� ��������� �� ������� � �����������
        StartCoroutine(FadeInBlack());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == hero)
        {
            // �������� ���� ������� �� ����� ������
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
            // ���������� �������� ���� �������
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
            color.a = 1f - (timer / fadeDuration); // ��������� ����� �� 1 �� 0
            blackimg.color = color;
            yield return null;
        }

        color.a = 0f; // ��������� ����������
        blackimg.color = color;
    }

    private IEnumerator FadeOutBlack()
    {
        float timer = 0f;
        Color color = blackimg.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // ����������� ����� �� 0 �� 1
            blackimg.color = color;
            yield return null;
        }

        color.a = 1f; // ��������� ������ �����
        blackimg.color = color;

        // ������� � ��������� �����
        SceneManager.LoadScene("Main");
    }

    // ����� ��� ��������� ����� �������
    private void SetObjectColor(Color color)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }
}