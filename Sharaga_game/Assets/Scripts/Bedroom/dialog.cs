using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject hero;

    void Start()
    {

        // ��������� ������ ��������� ������
        StartCoroutine(ActivateButtonAfterDelay());
    }

    private IEnumerator ActivateButtonAfterDelay()
    {
        // ��� 2 �������
        yield return new WaitForSeconds(1f);

    }
}
