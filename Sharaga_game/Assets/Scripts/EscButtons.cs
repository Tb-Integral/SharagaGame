using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscButtons : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

    public void _return()
    {
        gameObject.SetActive(false);
    }

    public void _goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void _exit()
    {
        Application.Quit();
    }
}
