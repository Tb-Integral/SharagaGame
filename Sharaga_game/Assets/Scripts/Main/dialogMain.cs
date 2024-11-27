using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dialogMain : MonoBehaviour
{
    [SerializeField] private Hero hero;

    void Start()
    {
        StartCoroutine(ActivateButtonAfterDelay());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Progress.Instance.first = false;
            hero.enabled = true;
            gameObject.SetActive(false);
        }
    }

    private IEnumerator ActivateButtonAfterDelay()
    {
        // ∆дЄм 2 секунды
        yield return new WaitForSeconds(1f);
    }
}
