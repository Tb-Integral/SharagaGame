using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //дверь подсвечивается
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("lvl2");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //дверь обратно
    }
}