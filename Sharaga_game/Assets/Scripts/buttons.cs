using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{

    public void door1()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void door2()
    {
        SceneManager.LoadScene("lvl2");
    }
    public void door3()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void gotomenu()
    {
        SceneManager.LoadScene("Main");
    }
}
