using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class monster : MonoBehaviour
{
    [SerializeField] private GameObject _hero;
    [SerializeField] private GameObject image;
    [SerializeField] private float imageDuration = 7f;
    private bool isPlayerInTrigger = false;
    private herolvl2 hero;
    private Rigidbody2D rb;

    private void Start()
    {
        hero = _hero.GetComponent<herolvl2>();
        rb = _hero.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerInTrigger = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerInTrigger)
        {
            StartCoroutine(ShowMonster());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInTrigger = false;
    }

    private IEnumerator ShowMonster()
    {
        rb.velocity = Vector2.zero;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        hero.enabled = false;
        image.SetActive(true);
        float timer = 0f;
        while (timer < imageDuration)
        {
            timer += Time.deltaTime;
            image.transform.localScale += new Vector3(0.08f, 0.08f, 0) * Time.deltaTime;
            image.transform.position -= new Vector3(0, 0.4f, 0) * Time.deltaTime;
            yield return null;
        }
        image.SetActive(false);
        hero.enabled = true;
    }
}
