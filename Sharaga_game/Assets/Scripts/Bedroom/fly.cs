using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    public float amplitude = 1f; // ��������� ��������
    public float speed = 2f;     // �������� ��������

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // ���������� ��������� �������
    }

    void Update()
    {
        // ������ ������� �� ��� Y �� ������ ���������
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
