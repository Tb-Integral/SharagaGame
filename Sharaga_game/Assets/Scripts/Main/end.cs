using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class end : MonoBehaviour
{
    [SerializeField] private Hero hero;
    [SerializeField] private Image black;

    void Start()
    {
        StartCoroutine(ActivateButtonAfterDelay());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(GoToEnd());
        }
    }

    private IEnumerator ActivateButtonAfterDelay()
    {
        // ��� 2 �������
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator GoToEnd()
    {
        float timer = 0f;
        Color color = black.color;

        while (timer < 2f)
        {
            timer += Time.deltaTime;
            color.a = timer / 2f;
            black.color = color;
            yield return null;
        }

        color.a = 1f;
        black.color = color;
        SceneManager.LoadScene("Menu");
    }
}
