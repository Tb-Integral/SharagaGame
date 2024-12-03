using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroMovementLvl3 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer; // слой земли дл€ проверки
    [SerializeField] private float jumpForce; // сила прыжка
    [SerializeField] private Image fadeImage;

    [SerializeField] private BoxCollider2D stand;

    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded;
    public bool CanMove = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsJumping = false;
        bool IsWalking = false;
        bool IsRunning = false;

        if (transform.position.y < -34f)
        {
            StartCoroutine(FadeOut());
        }

        if (CanMove)
        {
            if (Input.GetKey(KeyCode.D) && transform.position.x < 119.09f)
            {

                stand.enabled = true;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    IsRunning = true;
                    transform.position += new Vector3(speed, 0, 0) * Time.deltaTime * 2;

                }
                else
                {
                    transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                    IsWalking = true;
                }

                // ”становить поворот вправо, сохран€€ текущие y и z
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            if (Input.GetKey(KeyCode.A) && transform.position.x > -31.8f)
            {
                stand.enabled = true;

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    IsRunning = true;
                    transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime * 2;
                }
                else
                {
                    transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

                    IsWalking = true;
                }

                // ”становить поворот влево, сохран€€ текущие y и z
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

            float rayLength = 2f;
            Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.5f);

            // Raycast без сло€ дл€ отладки
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);

            if (hit.collider != null)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
                IsJumping = true;
            }

            // ѕрыжок
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                IsJumping = true;
            }
        }
        

        // ѕередаем значение параметру анимации
        anim.SetBool("IsWalking", IsWalking);
        anim.SetBool("IsJumping", IsJumping);
        anim.SetBool("IsRunning", IsRunning);
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < 1f)
        {
            timer += Time.deltaTime;
            color.a = timer / 1f;
            fadeImage.color = color;
            yield return null;
        }
        color.a = 1f;
        fadeImage.color = color;

        SceneManager.LoadScene("Main");
    }

}
