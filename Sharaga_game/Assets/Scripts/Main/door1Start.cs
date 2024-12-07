using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class door1Start : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    private Hero hero;
    private Rigidbody2D rb;
    [SerializeField] private Image black;

    public float fadeDuration = 2f;

    private void Start()
    {
        GameObject _hero = GameObject.Find("Player");
        hero = _hero.GetComponent<Hero>();
        rb = _hero.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        hero.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isPlayerInTrigger = true;
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            hero.enabled = true;
            StartCoroutine(GoToLvl());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInTrigger = false;
    }

    private IEnumerator GoToLvl()
    {
        Debug.Log("FadeOut");
        float timer = 0f;
        Color color = black.color;

        while (timer < fadeDuration)
        {
            Debug.Log("perehod");
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // Увеличиваем альфа от 0 до 1
            black.color = color;
            yield return null;
        }

        color.a = 1f;
        black.color = color;

        SceneManager.LoadScene("lvl1");
    }
}
