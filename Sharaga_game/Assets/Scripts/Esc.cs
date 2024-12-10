using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private AudioSource click;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            click.Play();
            Menu.SetActive(true);
        }
    }
}
