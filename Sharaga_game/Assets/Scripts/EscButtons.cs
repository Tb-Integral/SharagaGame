using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscButtons : MonoBehaviour
{
    void OnGUI()
    {
        GUIStyle style = new GUIStyle(); // стиль мощный для фпс
        style.fontSize = 24; // размер 24
        style.normal.textColor = Color.white; 

        // отображаем фпс
        GUI.Label(new Rect(10, 10, 200, 40), "FPS: " + (1.0f / Time.deltaTime).ToString("F2"), style);
    }
    void Update()
    {
        // если нажимаем esc то возвращаемся в игру
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

    public void _return()
    {
        // если нажимаем на кнопку продолжить то возвращаемся в игру
        gameObject.SetActive(false);
    }

    public void _goToMenu()
    {
        // если нажимаем на кнопку меню то загружаем главное меню игры
        SceneManager.LoadScene("Menu");
    }

    public void _exit()
    {
        Application.Quit();
    }
}
