using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fake : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
