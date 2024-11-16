using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsWalking = false;

        if (Input.GetKey(KeyCode.D) && transform.position.x < 6f)
        {
            
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

            // ”становить поворот вправо, сохран€€ текущие y и z
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            IsWalking = true;
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -6f)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            // ”становить поворот влево, сохран€€ текущие y и z
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            
            IsWalking = true;
        }

        // ѕередаем значение параметру анимации
        anim.SetBool("IsWalking", IsWalking);
    }

}
