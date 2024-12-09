using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_norm : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer; // слой земли дл€ проверки
    [SerializeField] private float jumpForce; // сила прыжка

    [SerializeField] private CapsuleCollider2D stand;
    [SerializeField] private BoxCollider2D down;
    [SerializeField] private AudioSource running;
    [SerializeField] private AudioSource walking;
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource slide;

    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool slideBro = false;
    private bool jumpBro = false;
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
        bool IsSliding = false;

        if (CanMove)
        {
            if (Input.GetKey(KeyCode.D) && transform.position.x < 152f)
            {
                if (!slideBro)
                {
                    stand.enabled = true;
                    down.enabled = false;
                }
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

                if (Input.GetKeyDown(KeyCode.S))
                {
                    IsSliding = true;
                    IsWalking = false;
                    IsRunning = false;

                    stand.enabled = false;
                    down.enabled = true;
                    slideBro = true;
                    StartCoroutine(Sliding());
                }

                // ”становить поворот вправо, сохран€€ текущие y и z
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            if (Input.GetKey(KeyCode.A) && transform.position.x > -8f)
            {
                if (!slideBro)
                {
                    stand.enabled = true;
                    down.enabled = false;
                }
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

                if (Input.GetKeyDown(KeyCode.S))
                {
                    IsSliding = true;
                    IsWalking = false;
                    IsRunning = false;

                    stand.enabled = false;
                    down.enabled = true;
                    slideBro = true;
                    StartCoroutine(Sliding());
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
                jumpBro = true;
                StartCoroutine(Jumping());
            }

            if (slideBro)
            {
                IsSliding = true;
                IsWalking = false;
                IsRunning = false;
            }

            if (jumpBro)
            {
                IsJumping = true;
                IsWalking = false;
                IsRunning = false;
            }
        }
        if (!IsWalking)
        {
            walking.Play();
        }

        if (!IsRunning)
        {
            running.Play();
        }
        if (!IsJumping)
        {
            jump.Play();
        }
        if (!IsSliding)
        {
            slide.Play();
        }



        anim.SetBool("IsWalking", IsWalking);
        anim.SetBool("IsJumping", IsJumping);
        anim.SetBool("IsRunning", IsRunning);
        anim.SetBool("IsSliding", IsSliding);
    }

    private IEnumerator Sliding()
    {
        yield return new WaitForSeconds(0.8f);
        stand.enabled = true;
        down.enabled = false;
        slideBro = false;
    }

    private IEnumerator Jumping()
    {
        yield return new WaitForSeconds(0.8f);
        jumpBro = false;
    }

}
