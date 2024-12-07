using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCircles : MonoBehaviour
{
    [SerializeField] private GameObject trashDialog;
    private bool isPlayerInTrigger = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerInTrigger = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerInTrigger)
        {
            trashDialog.SetActive(true);
            gameObject.GetComponent<trashCircles>().enabled = false;
        }
    }
}
