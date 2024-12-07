using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    [SerializeField] private GameObject lightOff;
    [SerializeField] private SpriteRenderer hero;
    public bool IsLightOff = false;
    private bool IsInTrigger = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsInTrigger = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsInTrigger) 
        {
            lightOff.SetActive(true);
            hero.color = Color.grey;
            IsLightOff = true;
            this.enabled = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsInTrigger = false;
    }
}
