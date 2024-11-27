using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour
{
    [SerializeField] private SpriteRenderer lvl1;
    [SerializeField] private SpriteRenderer lvl2;
    [SerializeField] private SpriteRenderer lvl3;

    public static Progress Instance; // ������� Singleton ��� ������� �� ������ �������
    public bool lvl1_check = false;
    public bool lvl2_check = false;
    public bool lvl3_check = false;
    public bool first = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // ������������� Singleton
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //void Start()
    //{
    //    string currentSceneName = SceneManager.GetActiveScene().name;
    //    if (lvl1_check) Debug.Log("lvl1 finish!");

    //    if (currentSceneName == "Main")
    //    {
    //        if (lvl1_check)
    //            lvl1.SetActive(true);
    //        if (lvl2_check)
    //            lvl2.SetActive(true);
    //        if (lvl3_check)
    //            lvl3.SetActive(true);
    //    }
    //}

    private void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (lvl1_check) Debug.Log("lvl1 finish!");

        if (currentSceneName == "Main")
        {
            if (lvl1 == null) lvl1 = GameObject.Find("eye door1").GetComponent<SpriteRenderer>();
            if (lvl2 == null) lvl2 = GameObject.Find("eye door2").GetComponent<SpriteRenderer>();
            if (lvl3 == null) lvl3 = GameObject.Find("eye door3").GetComponent<SpriteRenderer>();

            if (lvl1_check)
            {
                Color color = lvl1.color;  // �������� ������� ����
                color.a = 0f;            // ������������� �����-����� �� 1 (�����������)
                lvl1.color = color;        // ��������� ����� ����
            }
            if (lvl2_check)
            {
                Color color = lvl2.color;  // �������� ������� ����
                color.a = 0f;            // ������������� �����-����� �� 1 (�����������)
                lvl2.color = color;        // ��������� ����� ����
            }
            if (lvl3_check)
            {
                Color color = lvl3.color;  // �������� ������� ����
                color.a = 0f;            // ������������� �����-����� �� 1 (�����������)
                lvl3.color = color;        // ��������� ����� ����
            }
        }
    }
}
