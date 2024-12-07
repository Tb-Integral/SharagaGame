using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog2 : MonoBehaviour
{
    [SerializeField] private GameObject dialog3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialog3.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
