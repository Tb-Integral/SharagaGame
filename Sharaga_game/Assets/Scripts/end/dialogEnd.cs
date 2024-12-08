using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogEnd : MonoBehaviour
{
    [SerializeField] private GameObject img;
    [SerializeField] private SpriteRenderer player;
    [SerializeField] private robMove robMove;
    private bool isPlayerInTrigger = false;
    private Rigidbody2D rb;

    private void Start()
    {
        GameObject _hero = GameObject.Find("Player");
        rb = _hero.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isPlayerInTrigger = true;
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            img.SetActive(true);
            player.color = Color.gray;
            Color color = player.color;
            color.a = 1f;
            player.color = color;
            robMove.IsDialogEnd = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInTrigger = false;
    }
}
