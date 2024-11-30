using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sadnessDialog1 : MonoBehaviour
{
    [SerializeField] private herolvl2 hero;
    [SerializeField] private GameObject dialog1;
    [SerializeField] private GameObject dialog2;
    [SerializeField] private GameObject icon;
    [SerializeField] private circlesManager cm;
    [SerializeField] private GameObject circleIcon;
    [SerializeField] private Image fadeImage; // Привязать белое изображение
    [SerializeField] private float fadeDuration = 2f;
    private bool IsDialoFfirst = true;
    GameObject progress;
    Progress _progress;
    private bool isPlayerInTrigger = false;

    private void Start()
    {
        progress = GameObject.Find("progress manager");
        _progress = progress.GetComponent<Progress>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerInTrigger = true;
        if (IsDialoFfirst || cm.HaveCircleSad)
        {
            icon.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerInTrigger)
        {
            if (IsDialoFfirst)
            {
                IsDialoFfirst = false;
                dialog1.SetActive(true);
            }
            else if (cm.HaveCircleSad)
            {
                cm.circlesCount--;
                cm.AllCircles++;
                dialog2.SetActive(true);
                circleIcon.SetActive(false);
                cm.HaveCircleSad = false;
                if (cm.AllCircles == 3)
                {
                    StartCoroutine(FadeOut());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInTrigger = false;
        icon.SetActive(false);
    }

    private IEnumerator FadeOut()
    {
        _progress.lvl2_check = true;
        yield return new WaitForSeconds(2f);
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // Уменьшаем альфа-канал от 1 до 0
            fadeImage.color = color;
            yield return null;
        }
        color.a = 1f; // Полностью прозрачный экран
        fadeImage.color = color;
        _progress.lvl2_check = true;
        SceneManager.LoadScene("Main");
    }
}
