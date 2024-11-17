using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject hero;
    private Hero herom;


    void Start()
    {
        herom = hero.GetComponent<Hero>();

        // ��������� ������ ��������� ������
        StartCoroutine(ActivateButtonAfterDelay());
    }

    private IEnumerator ActivateButtonAfterDelay()
    {
        // ��� 2 �������
        yield return new WaitForSeconds(1f);

        // ���������� button1 ����� ��������
        button1.SetActive(true);

    }


    public void Perehod()
    {
        herom.enabled = true;
        gameObject.SetActive(false);
    }
}
