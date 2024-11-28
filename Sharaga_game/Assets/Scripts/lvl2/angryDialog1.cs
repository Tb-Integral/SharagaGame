using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angryDialog1 : MonoBehaviour
{
    [SerializeField] private herolvl2 hero;
    [SerializeField] private GameObject dialog1;
    private int dialogCount = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (dialogCount == 0)
            {
                dialog1.SetActive(true);
            }
            dialogCount++;
        }
    }
}
