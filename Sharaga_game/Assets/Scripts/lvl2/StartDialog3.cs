using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog3 : MonoBehaviour
{
    [SerializeField] private herolvl2 hero;
    [SerializeField] private AudioSource dialogSound;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogSound.Play();
            hero.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
