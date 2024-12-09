using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialoglvl2 : MonoBehaviour
{
    [SerializeField] private AudioSource dialogSound;
    private bool isPlayerInTrigger = false;
    private herolvl2 hero;
    private Rigidbody2D rb;

    private void Start()
    {
        GameObject _hero = GameObject.Find("Player");
        hero = _hero.GetComponent<herolvl2>();
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
            dialogSound.Play();
            hero.enabled = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInTrigger = false;
    }
}
