using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    private Hero hero;

    private void Start()
    {
        GameObject _hero = GameObject.Find("Player");
        hero = _hero.GetComponent<Hero>();
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
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInTrigger = false;
    }
}
