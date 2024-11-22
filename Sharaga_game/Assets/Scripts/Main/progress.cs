using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    [SerializeField] private GameObject lvl1;
    [SerializeField] private GameObject lvl2;
    [SerializeField] private GameObject lvl3;

    public static Progress Instance; // —оздаем Singleton дл€ доступа из других классов

    void Awake()
    {
        // √арантируем, что есть только один экземпл€р Progress
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Ch_lvl1() => lvl1.SetActive(true);
    public void Ch_lvl2() => lvl2.SetActive(true);
    public void Ch_lvl3() => lvl3.SetActive(true);
}
