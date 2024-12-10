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
    [SerializeField] private AudioSource audio;
    [SerializeField] private float targetVolume = 0.18f; // Целевая громкость
    [SerializeField] private AudioSource walking;
    [SerializeField] private SpriteRenderer imgBed;

    public Image whiteimg; // Привязать белое изображение
    public Image blackimg; // Привязать черное изображение
    public float fadeDuration = 2f;

    private bool isPlayerInTrigger = false;

    void Start()
    {
        audio.volume = 0f;

        // Установить черное изображение полностью непрозрачным
        Color blackColor = blackimg.color;
        blackColor.a = 1f; // Полностью черный
        blackimg.color = blackColor;

        // Установить белое изображение полностью прозрачным
        Color whiteColor = whiteimg.color;
        whiteColor.a = 0f; // Полностью прозрачное
        whiteimg.color = whiteColor;

        // Запустить затухание от черного к прозрачному
        StartCoroutine(FadeInBlack());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Color newColor = imgBed.color;
        if (offOn.IsLightOff)
        {
            newColor = new Color(80f / 255f, 80f / 255f, 80f / 255f);
        }
        else 
        {
            newColor = Color.gray;
        }
        imgBed.color = newColor;
        isPlayerInTrigger = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerInTrigger)
        {
            if (offOn.IsLightOff)
            {
                walking.Stop();
                hero.SetActive(false);
                img2.SetActive(true);
                img1.SetActive(false);

                // Начать затухание белого изображения
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
        Color newColor = imgBed.color;
        if (offOn.IsLightOff)
        {
            newColor = Color.gray;
        }
        else
        {
            newColor = Color.white;
        }
        imgBed.color = newColor;
        isPlayerInTrigger = false;
    }

    private IEnumerator FadeInBlack()
    {
        float timer = 0f;
        Color color = blackimg.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / fadeDuration); // Уменьшаем альфа от 1 до 0
            blackimg.color = color;
            audio.volume = Mathf.Lerp(0f, targetVolume, timer / fadeDuration);
            yield return null;
        }
        dialog.SetActive(true);

        color.a = 0f; // Полностью прозрачный
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
            color.a = timer / fadeDuration; // Увеличиваем альфа от 0 до 1
            whiteimg.color = color;
            //audio.volume = Mathf.Lerp(targetVolume, 0f, timer / fadeDuration);
            yield return null;
        }

        color.a = 1f; // Полностью белый экран
        whiteimg.color = color;

        // Переход к следующей сцене
        SceneManager.LoadScene("Main");
    }
}
