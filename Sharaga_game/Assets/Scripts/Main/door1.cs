using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //дверь подсвечивается
        Debug.Log("enter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("in");
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("lvl1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
        //дверь обратно
    }
}
