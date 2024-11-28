using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class herolvl2 : MonoBehaviour
{
    [SerializeField] private float speed = 2f;


    private Rigidbody2D rb;
    private Vector2 moveVector;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        rb.velocity = moveVector * speed;
    }



    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
