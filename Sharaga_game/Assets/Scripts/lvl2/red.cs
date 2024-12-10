using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour
{
    [SerializeField] private circlesManager cm;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject circle;
    [SerializeField] private AudioSource pick;
    private bool IsHeroOnTrigger = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsHeroOnTrigger = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && IsHeroOnTrigger)
        {
            pick.Play();
            cm.HaveCircleAngry = true;
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsHeroOnTrigger = false;
    }
}
