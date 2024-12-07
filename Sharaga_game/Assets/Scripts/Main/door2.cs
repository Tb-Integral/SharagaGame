using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class door2 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer door_act;
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject dialogStart;
    [SerializeField] private BoxCollider2D _collider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collider.enabled = true;
        Color color = door_act.color;
        color.a = 1f;
        door_act.color = color;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!Progress.Instance.lvl2_check)
            {
                dialogStart.SetActive(true);
            }
            else
            {
                dialog.SetActive(true);
                _collider.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Color color = door_act.color;
        color.a = 0f;
        door_act.color = color;
    }
}