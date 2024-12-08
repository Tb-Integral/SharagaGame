using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    public float amplitude = 1f; // Амплитуда движения
    public float speed = 2f;     // Скорость движения

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Запоминаем начальную позицию
    }

    void Update()
    {
        // Меняем позицию по оси Y на основе синусоиды
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
