using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog3 : MonoBehaviour
{
    [SerializeField] private herolvl2 hero;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hero.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
