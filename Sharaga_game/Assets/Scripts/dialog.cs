using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    [SerializeField] private GameObject bed_button;
    [SerializeField] private Button button2;
    [SerializeField] private GameObject button1;

    void Start()
    {
        StartCoroutine(ActivateButtonAfterDelay());
    }

    private IEnumerator ActivateButtonAfterDelay()
    {
        // ∆дЄм 2 секунды
        yield return new WaitForSeconds(1f);

        // јктивируем button1 после задержки
        button1.SetActive(true);
    }

    public void perehod()
    {
        button2.interactable = true;
        gameObject.SetActive(false);
    }
}
