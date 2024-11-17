using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject hero;
    private Hero herom;


    void Start()
    {
        herom = hero.GetComponent<Hero>();

        // Запускаем таймер активации кнопки
        StartCoroutine(ActivateButtonAfterDelay());
    }

    private IEnumerator ActivateButtonAfterDelay()
    {
        // Ждём 2 секунды
        yield return new WaitForSeconds(1f);

        // Активируем button1 после задержки
        button1.SetActive(true);

    }


    public void Perehod()
    {
        herom.enabled = true;
        gameObject.SetActive(false);
    }
}
