using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class angryDialog1 : MonoBehaviour
{
    [SerializeField] private herolvl2 hero;
    [SerializeField] private GameObject dialog1;
    [SerializeField] private GameObject dialog2;
    [SerializeField] private GameObject icon;
    [SerializeField] private circlesManager cm;
    [SerializeField] private GameObject circleIcon;
    [SerializeField] private Image fadeImage; // Привязать белое изображение
    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private GameObject circles;
    [SerializeField] private GameObject panel;
    [SerializeField] private AudioSource pick;
    private bool IsDialoFfirst = true;
    GameObject progress;
    Progress _progress;
    private bool isPlayerInTrigger = false;

    private void Start()
    {
        progress = GameObject.Find("progress manager");
        _progress = progress.GetComponent<Progress>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerInTrigger = true;
        if (IsDialoFfirst || cm.HaveCircleAngry)
        {
            icon.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerInTrigger)
        {
            if (IsDialoFfirst)
            {
                pick.Play();
                hero.walk.Stop();
                IsDialoFfirst = false;
                dialog1.SetActive(true);
            }
            else if (cm.HaveCircleAngry)
            {
                pick.Play();
                hero.walk.Stop();
                cm.circlesCount--;
                if (cm.CircleMas[0] && cm.CircleMas[1] && cm.CircleMas[2])
                {
                    if (circleIcon.transform.localPosition.x - 1.5194717f < 1.0f)
                    {
                        Debug.Log(1);
                        cm.CircleMas[1] = cm.CircleMas[0];
                        cm.CircleMas[1].transform.localPosition += new Vector3(30.29254f, 0, 0);
                    }
                    else if (circleIcon.transform.localPosition.x - 31.8120117f < 1.0f)
                    {
                        Debug.Log(2);
                        cm.CircleMas[2] = cm.CircleMas[1];
                        cm.CircleMas[1] = cm.CircleMas[0];
                        cm.CircleMas[1].transform.localPosition += new Vector3(30.29254f, 0, 0);
                        cm.CircleMas[2].transform.localPosition += new Vector3(30.29254f, 0, 0);
                    }
                    cm.CircleMas[0] = null;
                }
                else if (cm.CircleMas[0] && cm.CircleMas[1])
                {
                    if (circleIcon.transform.localPosition.x + 28.7730683f < 1.0f)
                    {
                        cm.CircleMas[2] = cm.CircleMas[1];
                        cm.CircleMas[2].transform.localPosition += new Vector3(30.29254f, 0, 0);
                    }
                    else
                    {
                        cm.CircleMas[2] = cm.CircleMas[0];
                        cm.CircleMas[2].transform.localPosition += new Vector3(2 * 30.29254f, 0, 0);
                    }
                    cm.CircleMas[1] = null;
                    cm.CircleMas[0] = null;
                }
                else if (cm.CircleMas[0] && cm.CircleMas[2])
                {
                    if (circleIcon.transform.localPosition.x - 31.8120117f < 1.0f)
                    {
                        cm.CircleMas[2] = cm.CircleMas[0];
                        cm.CircleMas[2].transform.localPosition += new Vector3(2 * 30.29254f, 0, 0);
                    }
                    cm.CircleMas[0] = null;
                }
                else if (cm.CircleMas[1] && cm.CircleMas[2])
                {
                    if (circleIcon.transform.localPosition.x - 1.5194717f < 1.0f)
                    {
                        cm.CircleMas[2] = cm.CircleMas[1];
                        cm.CircleMas[2].transform.localPosition += new Vector3(30.29254f, 0, 0);
                    }
                    cm.CircleMas[1] = null;
                }
                else
                {
                    cm.CircleMas[0] = null;
                    cm.CircleMas[1] = null;
                    cm.CircleMas[2] = null;
                    panel.SetActive(false);
                }
                cm.AllCircles++;
                cm.HaveCircleAngry = false;
                circleIcon.SetActive(false);
                dialog2.SetActive(true);
                if (cm.AllCircles ==3)
                {
                    StartCoroutine(FadeOut());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        icon.SetActive(false);
        isPlayerInTrigger = false;
    }

    private IEnumerator FadeOut()
    {
        _progress.lvl2_check = true;
        yield return new WaitForSeconds(2f);
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // Уменьшаем альфа-канал от 1 до 0
            fadeImage.color = color;
            yield return null;
        }
        color.a = 1f; // Полностью прозрачный экран
        fadeImage.color = color;
        SceneManager.LoadScene("Main");
    }
}
