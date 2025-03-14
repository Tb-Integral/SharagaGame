using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class door2Start : MonoBehaviour
{
    [SerializeField] private AudioSource click;
    [SerializeField] private AudioSource walk;
    [SerializeField] private AudioSource doorSound;
    private bool isPlayerInTrigger = false;
    private Hero hero;
    private Rigidbody2D rb;
    [SerializeField] private Image black;

    public float fadeDuration = 2f;

    private void Start()
    {
        walk.Stop();
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
            click.Play();
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
        doorSound.Play();
        while (timer < fadeDuration)
        {
            Debug.Log("perehod");
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // ����������� ����� �� 0 �� 1
            black.color = color;
            yield return null;
        }

        color.a = 1f;
        black.color = color;

        SceneManager.LoadScene("lvl2");
    }
}
