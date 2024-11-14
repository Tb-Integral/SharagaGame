using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
    [SerializeField] private GameObject img1;
    [SerializeField] private GameObject img2;
    public void krovat()
    {
        img2.SetActive(true);
        img1.SetActive(false);
        gameObject.SetActive(false);
    }
}
