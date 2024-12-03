using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down : MonoBehaviour
{
    public float weightThreshold = 1f; // ��� ��� ��������� ��������
    public float moveSpeed = 2f; // �������� �������� ����/�����
    public float returnSpeed = 2f; // �������� �������� ���������
    private Rigidbody2D rb;
    private float currentWeight = 0f;
    private Vector2 startPosition; // ��������� ������� ���������
    private bool isMovingDown = false; // ���� �������� ����

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("�� ��������� ����������� Rigidbody2D!");
        }
        startPosition = transform.position; // ���������� ��������� �������
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                currentWeight += playerRb.mass; // ��������� ��� ������
                Debug.Log("Player entered: Current weight = " + currentWeight);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                currentWeight -= playerRb.mass; // ������� ��� ������
                Debug.Log("Player exited: Current weight = " + currentWeight);
            }
        }
    }

    private void FixedUpdate()
    {
        if (currentWeight >= weightThreshold)
        {
            // ������� ��������� ����
            rb.isKinematic = false;
            rb.velocity = new Vector2(0, -moveSpeed);
            isMovingDown = true;
        }
        else
        {
            if (isMovingDown)
            {
                // ��������� ����������� �������
                rb.isKinematic = true; // ������������� ���������� ��������
                Vector2 currentPosition = transform.position;
                Vector2 direction = startPosition - currentPosition;

                if (direction.magnitude > 0.1f) // ���� ��������� �� �� �����
                {
                    rb.velocity = new Vector2(0, returnSpeed); // ������� �����
                }
                else
                {
                    transform.position = startPosition; // ��������� �������
                    rb.velocity = Vector2.zero; // ������������� ��������
                    isMovingDown = false;
                }
            }
        }
    }

}
