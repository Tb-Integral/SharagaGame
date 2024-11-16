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
        // ��� 2 �������
        yield return new WaitForSeconds(1f);

        // ���������� button1 ����� ��������
        button1.SetActive(true);
    }

    public void perehod()
    {
        button2.interactable = true;
        gameObject.SetActive(false);
    }
}
