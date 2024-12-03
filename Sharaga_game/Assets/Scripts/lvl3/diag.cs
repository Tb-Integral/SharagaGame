using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diag : MonoBehaviour
{
    public float topY = 6.6f;      // ������� �������
    public float topX = 115f;      // ������� �������
    public float bottomY = -17.1f; // ������ �������
    public float bottomX = 88.7f; // ������ �������
    public float moveSpeed = 2f;   // �������� ��������
    private bool movingUp = true;  // ����������� ��������
    private Transform player;      // ������ �� ������
    private Vector2 lastPosition;  // ���������� ������� ���������

    private void Start()
    {
        lastPosition = transform.position; // ��������� ��������� �������
    }

    private void Update()
    {
        // ������� ��������� ����� ��� ����
        float step = moveSpeed * Time.deltaTime;
        float targetY = movingUp ? topY : bottomY;
        float targetX = movingUp ? topX : bottomX;

        transform.position = new Vector2(
            Mathf.MoveTowards(transform.position.x, targetX, step),
            Mathf.MoveTowards(transform.position.y, targetY, step)
        );

        // ������ �����������, ���� �������� �������
        if (Mathf.Abs(transform.position.y - targetY) < 0.1f)
        {
            movingUp = !movingUp;
        }

        // ��������� ������� ������, ���� �� �� ���������
        if (player != null)
        {
            Vector2 platformDelta = (Vector2)transform.position - lastPosition;
            player.position += (Vector3)platformDelta;
        }

        lastPosition = transform.position; // ��������� ��������� �������
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform; // ���������� ������
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null; // ������� ������ �� ������
        }
    }
}
