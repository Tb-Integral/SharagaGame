using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void nachat()
    {
        SceneManager.LoadScene("Bedroom");
        Debug.Log("qwewqewq");
    }

    public void exit()
    {
        Application.Quit();
    }
}
