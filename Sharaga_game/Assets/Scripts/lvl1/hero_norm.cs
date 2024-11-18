using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_norm : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer; // ���� ����� ��� ��������
    [SerializeField] private float jumpForce; // ���� ������

    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Debug.Log("groundLayer mask: " + groundLayer.value);

    }

    // Update is called once per frame
    void Update()
    {

        bool IsWalking = false;

        if (Input.GetKey(KeyCode.D) && transform.position.x < 71f)
        {
            
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

            // ���������� ������� ������, �������� ������� y � z
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            IsWalking = true;
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -8f)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            // ���������� ������� �����, �������� ������� y � z
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            
            IsWalking = true;
        }
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        float rayLength = 2f; // ���������� ��������� ��������
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.5f);

        // Raycast ��� ���� ��� �������
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);
        // ������ ��� � ������� ��������� � �������

        if (hit.collider != null)
        {
            isGrounded = true;
            Debug.Log("�� �����: " + hit.collider.gameObject.name);
        }
        else
        {
            isGrounded = false;
            Debug.Log("�� �� �����");
        }

        // ������
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("������!");
        }

        // �������� �������� ��������� ��������
        anim.SetBool("IsWalking", IsWalking);
    }

}
