using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boombox : MonoBehaviour
{
    // ссылки на треки дл€ бумбокса
    [SerializeField] private AudioSource music1; 
    [SerializeField] private AudioSource music2;
    [SerializeField] private AudioSource music3;
    // базова€ музыка спальни
    [SerializeField] private AudioSource baseMusic;
    // окно диалога дл€ каждого трека
    [SerializeField] private GameObject dialog1;
    [SerializeField] private GameObject dialog2;
    [SerializeField] private GameObject dialog3;

    // находитс€ ли роб в области коллайдера бумбокса
    private bool IsHeroOnTrigger = false;
    // кака€ музыка сейчас играет
    private bool basic = true;
    private bool anime = false;
    private bool albina = false;
    private bool rap = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // мен€ем цвет бумбокса когда подходим к нему
        Color color = Color.gray;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        IsHeroOnTrigger = true;
    }

    private void Update()
    {
        // проверка нажати€ spase и коллизии коллайдеров
        if(IsHeroOnTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            if (basic)
            {
                baseMusic.Pause();
                basic = false;
                rap = true;
                music1.Play();
                dialog1.SetActive(true);
            }
            else if (rap)
            {
                music1.Stop();
                rap = false;
                anime = true;
                music2.Play();
                dialog2.SetActive(true);
            }
            else if (anime)
            {
                music2.Stop();
                albina = true;
                anime = false;
                music3.Play();
                dialog3.SetActive(true);
            }
            else if (albina)
            {
                music3.Stop();
                albina = false;
                basic = true;
                baseMusic.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Color color = Color.white;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        IsHeroOnTrigger = false;
    }
}
