using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down : MonoBehaviour
{
    public float weightThreshold = 1f; // Вес для активации движения
    public float moveSpeed = 2f; // Скорость движения вниз/вверх
    public float returnSpeed = 2f; // Скорость возврата платформы
    private Rigidbody2D rb;
    private float currentWeight = 0f;
    private Vector2 startPosition; // Начальная позиция платформы
    private bool isMovingDown = false; // Флаг движения вниз

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("На платформе отсутствует Rigidbody2D!");
        }
        startPosition = transform.position; // Запоминаем стартовую позицию
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                currentWeight += playerRb.mass; // Добавляем вес игрока
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
                currentWeight -= playerRb.mass; // Убираем вес игрока
                Debug.Log("Player exited: Current weight = " + currentWeight);
            }
        }
    }

    private void FixedUpdate()
    {
        if (currentWeight >= weightThreshold)
        {
            // Двигаем платформу вниз
            rb.isKinematic = false;
            rb.velocity = new Vector2(0, -moveSpeed);
            isMovingDown = true;
        }
        else
        {
            if (isMovingDown)
            {
                // Платформа поднимается обратно
                rb.isKinematic = true; // Останавливаем физическое движение
                Vector2 currentPosition = transform.position;
                Vector2 direction = startPosition - currentPosition;

                if (direction.magnitude > 0.1f) // Если платформа не на месте
                {
                    rb.velocity = new Vector2(0, returnSpeed); // Двигаем вверх
                }
                else
                {
                    transform.position = startPosition; // Фиксируем позицию
                    rb.velocity = Vector2.zero; // Останавливаем движение
                    isMovingDown = false;
                }
            }
        }
    }

}
