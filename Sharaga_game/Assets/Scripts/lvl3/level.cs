using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.VersionControl;
using UnityEngine;

public class level : MonoBehaviour
{
    [SerializeField] private Sprite change;
    [SerializeField] private GameObject group;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Проверяем тег объекта
        {
            Color color = Color.grey;
            sr.color = color;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            group.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().sprite = change;
            Color color = Color.white;
            sr.color = color;
            gameObject.GetComponent<level>().enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Проверяем тег объекта
        {
            Color color = Color.white;
            sr.color = color;
        }
    }
}
