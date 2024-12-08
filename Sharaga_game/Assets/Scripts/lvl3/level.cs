using UnityEngine;

public class level : MonoBehaviour
{
    [SerializeField] private Sprite change;
    [SerializeField] private GameObject group;
    [SerializeField] private AudioSource click;
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
            click.Play();
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
