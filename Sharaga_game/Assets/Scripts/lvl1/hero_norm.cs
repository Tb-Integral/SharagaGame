using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_norm : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer; // ���� ����� ��� ��������
    [SerializeField] private float jumpForce; // ���� ������

    [SerializeField] private CapsuleCollider2D stand;
    [SerializeField] private BoxCollider2D down;

    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded;

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


        if (Input.GetKey(KeyCode.D) && transform.position.x < 152f)
        {

            stand.enabled = true;
            down.enabled = false;
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

            if (Input.GetKey(KeyCode.S))
            {
                IsSliding = true;
                IsWalking = false;
                IsRunning = false;

                stand.enabled = false;
                down.enabled = true;
            }

            // ���������� ������� ������, �������� ������� y � z
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -8f)
        {
            stand.enabled = true;
            down.enabled = false;

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

            if (Input.GetKey(KeyCode.S))
            {
                IsSliding = true;
                IsWalking = false;
                IsRunning = false;

                stand.enabled = false;
                down.enabled = true;
            }

            // ���������� ������� �����, �������� ������� y � z
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        float rayLength = 2f;
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.5f);

        // Raycast ��� ���� ��� �������
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

        // ������
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            IsJumping = true;
        }

        // �������� �������� ��������� ��������
        anim.SetBool("IsWalking", IsWalking);
        anim.SetBool("IsJumping", IsJumping);
        anim.SetBool("IsRunning", IsRunning);
        anim.SetBool("IsSliding", IsSliding);

    }

}
