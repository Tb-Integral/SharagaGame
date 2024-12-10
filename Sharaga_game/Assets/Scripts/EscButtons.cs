using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscButtons : MonoBehaviour
{
    void OnGUI()
    {
        GUIStyle style = new GUIStyle(); // ������� ����� ������
        style.fontSize = 24; // ������������� ������ ������ (��������, 24)
        style.normal.textColor = Color.white; // ���� ������ (����� ��������)

        // ���������� FPS � �������������� �����
        GUI.Label(new Rect(10, 10, 200, 40), "FPS: " + (1.0f / Time.deltaTime).ToString("F2"), style);
    }
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
