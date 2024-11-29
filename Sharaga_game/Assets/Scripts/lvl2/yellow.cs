using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellow : MonoBehaviour
{
    [SerializeField] private circlesManager cm;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject circle;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cm.HaveCircleJoy = true;
            cm.circlesCount++;
            if(cm.circlesCount == 1)
            {
                panel.SetActive(true);
            }
            circle.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
