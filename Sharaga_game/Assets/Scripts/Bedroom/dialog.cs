using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject hero;

    void Start()
    {

        // Запускаем таймер активации кнопки
        StartCoroutine(ActivateButtonAfterDelay());
    }

    private IEnumerator ActivateButtonAfterDelay()
    {
        // Ждём 2 секунды
        yield return new WaitForSeconds(1f);

    }
}
