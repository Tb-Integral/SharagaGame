using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diag : MonoBehaviour
{
    public float topY = 6.6f;      // Верхняя граница
    public float topX = 115f;      // Верхняя граница
    public float bottomY = -17.1f; // Нижняя граница
    public float bottomX = 88.7f; // Нижняя граница
    public float moveSpeed = 2f;   // Скорость движения
    private bool movingUp = true;  // Направление движения
    private Transform player;      // Ссылка на игрока
    private Vector2 lastPosition;  // Предыдущая позиция платформы

    private void Start()
    {
        lastPosition = transform.position; // Сохраняем начальную позицию
    }

    private void Update()
    {
        // Двигаем платформу вверх или вниз
        float step = moveSpeed * Time.deltaTime;
        float targetY = movingUp ? topY : bottomY;
        float targetX = movingUp ? topX : bottomX;

        transform.position = new Vector2(
            Mathf.MoveTowards(transform.position.x, targetX, step),
            Mathf.MoveTowards(transform.position.y, targetY, step)
        );

        // Меняем направление, если достигли границы
        if (Mathf.Abs(transform.position.y - targetY) < 0.1f)
        {
            movingUp = !movingUp;
        }

        // Обновляем позицию игрока, если он на платформе
        if (player != null)
        {
            Vector2 platformDelta = (Vector2)transform.position - lastPosition;
            player.position += (Vector3)platformDelta;
        }

        lastPosition = transform.position; // Обновляем последнюю позицию
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform; // Запоминаем игрока
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null; // Убираем ссылку на игрока
        }
    }
}
