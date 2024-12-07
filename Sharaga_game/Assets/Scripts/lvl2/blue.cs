using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue : MonoBehaviour
{
    [SerializeField] private circlesManager cm;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject circle;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cm.HaveCircleSad = true;
            cm.circlesCount++;
            if (cm.CircleMas[2])
            {
                if (cm.CircleMas[1])
                {
                    cm.CircleMas[0] = circle;
                    circle.SetActive(true);
                    circle.transform.localPosition = new Vector3(-28.7730683f, 0, 0);
                }
                else
                {
                    cm.CircleMas[1] = circle;
                    circle.SetActive(true);
                    circle.transform.localPosition = new Vector3(1.5194717f, 0, 0);
                }
            }
            else
            {
                cm.CircleMas[2] = circle;
                panel.SetActive(true);
                circle.SetActive(true);
                circle.transform.localPosition = new Vector3(31.8120117f, 0, 0);
            }
            gameObject.SetActive(false);
        }
    }
}
