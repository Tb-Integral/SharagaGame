using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour
{
    [SerializeField] private GameObject bed_button;

    public void perehod()
    {
        bed_button.SetActive(true);
        gameObject.SetActive(false);
    }

}
