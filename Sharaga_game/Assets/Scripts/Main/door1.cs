using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class door1 : MonoBehaviour
{
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject dialogStart;
    [SerializeField] private SpriteRenderer door_act;
    [SerializeField] private BoxCollider2D _collider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collider.enabled = true;
        Color color = door_act.color;
        color.a = 1f;
        door_act.color = color;

        Debug.Log("enter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("in");
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(Progress.Instance.lvl1_check);
            if (!Progress.Instance.lvl1_check)
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
        Debug.Log("exit");
        Color color = door_act.color;
        color.a = 0f;
        door_act.color = color;
    }
}
