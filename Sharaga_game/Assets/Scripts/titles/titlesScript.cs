using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titlesScript : MonoBehaviour
{
    [SerializeField] private Image black;
    void Start()
    {
        StartCoroutine(qwerty());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private IEnumerator qwerty()
    {
        float timer = 0f;
        while (timer < 2f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;
        Color color = black.color;

        while (timer < 3f)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / 3f); // Уменьшаем прозрачность от 1 до 0
            black.color = color;
            yield return null;
        }
        color.a = 0f; // прозрачность белого экрана на 0
        black.color = color;

        timer = 0f;
        while (timer < 1f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;
        while (timer < 73f)
        {
            timer += Time.deltaTime;
            gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
            yield return null;
        }

        timer = 0f;
        while (timer < 2f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;
        color = black.color;

        while (timer < 3f)
        {
            timer += Time.deltaTime;
            color.a = timer / 3f;
            black.color = color;
            yield return null;
        }
        color.a = 1f;
        black.color = color;
        SceneManager.LoadScene("Menu");
    }
}
