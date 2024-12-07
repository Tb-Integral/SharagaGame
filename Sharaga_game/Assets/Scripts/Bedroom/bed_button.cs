using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bed_button : MonoBehaviour
{
    [SerializeField] private light offOn;
    [SerializeField] private GameObject img1;
    [SerializeField] private GameObject img2;
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject dialogBedNo;

    public Image whiteimg; // ��������� ����� �����������
    public Image blackimg; // ��������� ������ �����������
    public float fadeDuration = 2f;

    private Image targetImage;
    private bool isPlayerInTrigger = false;

    void Start()
    {
        targetImage = GetComponent<Image>();

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Color newColor = targetImage.color;
        //newColor = Color.gray;
        //targetImage.color = newColor;
        isPlayerInTrigger = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerInTrigger)
        {
            if (offOn.IsLightOff)
            {
                hero.SetActive(false);
                img2.SetActive(true);
                img1.SetActive(false);

                // ������ ��������� ������ �����������
                StartCoroutine(FadeOutWhite());
            }
            else
            {
                dialogBedNo.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Color newColor = targetImage.color;
        //newColor = Color.white;
        //targetImage.color = newColor;
        isPlayerInTrigger = false;
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
        dialog.SetActive(true);

        color.a = 0f; // ��������� ����������
        blackimg.color = color;
    }

    private IEnumerator FadeOutWhite()
    {

        yield return new WaitForSeconds(1f);
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
