using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] private AudioSource click;
    public void nachat()
    {
        click.Play();
        StartCoroutine(ZHOPA());
    }

    public void exit()
    {
        click.Play();
        Application.Quit();
    }

    private IEnumerator ZHOPA()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Bedroom");
    }
}
