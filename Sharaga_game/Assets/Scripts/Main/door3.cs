using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //����� ��������������
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("lvl3");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //����� �������
    }
}