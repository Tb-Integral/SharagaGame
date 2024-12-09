using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCircles : MonoBehaviour
{
    [SerializeField] private GameObject trashDialog;
    [SerializeField] private AudioSource pick;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerInTrigger = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerInTrigger)
        {
            hero.walk.Stop();
            pick.Play();
            trashDialog.SetActive(true);
            gameObject.GetComponent<trashCircles>().enabled = false;
        }
    }
}
