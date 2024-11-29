using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class joyDialog1 : MonoBehaviour
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
        if (IsDialoFfirst || cm.HaveCircleJoy)
        {
            icon.SetActive(true);
        }
        isPlayerInTrigger = true;
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
            else if (cm.HaveCircleJoy)
            {
                cm.circlesCount--;
                cm.HaveCircleJoy = false;
                circleIcon.SetActive(false);
                dialog2.SetActive(true);
                if (cm.circlesCount == 0)
                {
                    StartCoroutine(FadeOut());
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        icon.SetActive(false);
        isPlayerInTrigger = false;
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
        SceneManager.LoadScene("Main");
    }
}
