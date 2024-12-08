using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour
{
    [SerializeField] private AudioSource click;
    [SerializeField] private AudioSource walk;
    private bool isPlayerInTrigger = false;
    private Hero hero;
    private Rigidbody2D rb;

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
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInTrigger = false;
    }
}
