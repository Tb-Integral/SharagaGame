using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    [SerializeField] private GameObject lightOff;
    [SerializeField] private SpriteRenderer hero;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioSource audio2;
    [SerializeField] private AudioSource clickSound;
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
            clickSound.Play();
            lightOff.SetActive(true);
            audio.volume = 0f;
            audio2.volume = 0.5f;
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
