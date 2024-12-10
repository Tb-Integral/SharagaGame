using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class head : MonoBehaviour
{
    [SerializeField] private Hero_norm managment;
    [SerializeField] private Animator anim;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject text2;
    [SerializeField] private Image black;
    [SerializeField] private BoxCollider2D door;
    public bool IsDead = false;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //aud = GetComponent<AudioSource>();
        speed = 9.5f;
        StartCoroutine(Enum()); // Запускаем корутину правильно
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.enabled = false;
        Color color = black.color;
        IsDead = true;
        managment.CanMove = false;
        anim.SetBool("IsDead", IsDead);
        speed = 0;
        color.a = 0.8f;
        black.color = color;
        text2.SetActive(true);
        StartCoroutine(Dead());

    }

    private IEnumerator Enum()
    {
        for (int i = 5; i > -1; i--)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        text.enabled = false;
        //speed = 9.5f;
        //aud.Play();
    }

    private IEnumerator Dead()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main");
    }
}
