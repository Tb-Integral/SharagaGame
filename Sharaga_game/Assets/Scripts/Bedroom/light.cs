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
    [SerializeField] private SpriteRenderer bed;
    [SerializeField] private GameObject boombox;
    [SerializeField] private AudioSource music1;
    [SerializeField] private AudioSource music2;
    [SerializeField] private AudioSource music3;
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
            music1.Stop();
            music2.Stop();
            music3.Stop();
            clickSound.Play();
            lightOff.SetActive(true);
            audio.Stop();
            audio2.Play();
            audio2.volume = 0.5f;
            hero.color = Color.grey;
            IsLightOff = true;
            bed.color = Color.gray;
            boombox.SetActive(false);
            this.enabled = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsInTrigger = false;
    }
}
