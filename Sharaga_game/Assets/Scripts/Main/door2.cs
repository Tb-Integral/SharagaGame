using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door2 : MonoBehaviour
{
    [SerializeField] private GameObject door_act;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        door_act.SetActive(true);
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
        door_act.SetActive(false);
    }
}