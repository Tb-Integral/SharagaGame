using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class door1 : MonoBehaviour
{
    [SerializeField] private GameObject dialog;
    [SerializeField] private SpriteRenderer door_act;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Image black;

    public float fadeDuration = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collider.enabled = true;
        Color color = door_act.color;
        color.a = 1f;
        door_act.color = color;

        Debug.Log("enter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("in");
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(Progress.Instance.lvl1_check);
            if (!Progress.Instance.lvl1_check)
            {
                StartCoroutine(FadeOut());
            }
            else
            {
                dialog.SetActive(true);
                _collider.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
        Color color = door_act.color;
        color.a = 0f;
        door_act.color = color;
    }

    private IEnumerator FadeOut()
    {
        Debug.Log("FadeOut");
        float timer = 0f;
        Color color = black.color;

        while (timer < fadeDuration)
        {
            Debug.Log("perehod");
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // Увеличиваем альфа от 0 до 1
            black.color = color;
            yield return null;
        }

        color.a = 1f;
        black.color = color;

        SceneManager.LoadScene("lvl1");
    }
}
