using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class robMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject blackDoor;
    [SerializeField] private GameObject whiteDoor;
    [SerializeField] private GameObject whiteDoor2;
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject dialogGolos;
    [SerializeField] private AudioSource walk;
    [SerializeField] private AudioSource door;
    [SerializeField] private AudioSource lighrEffect;
    private Animator anim;
    private bool IsWalking = false;
    public bool IsDialogEnd = false;

    private bool isMoving = false; // ���� ��� ��������, �������� �� ������

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDialogEnd && !isMoving)
        {
            StartCoroutine(Move());
        }

        anim.SetBool("IsWalking", IsWalking);
    }

    private IEnumerator Move()
    {
        isMoving = true; // ������������� ����, ����� ������������� ��������� ������
        IsWalking = true;

        walk.Play();
        float timer = 0f;
        while (timer < 3f)
        {
            timer += Time.deltaTime;
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            // ���������� ������� �����, �������� ������� y � z
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            yield return null;
        }
        walk.Stop();

        IsWalking = false;
        IsDialogEnd = false;
        isMoving = false; // ���������� ���� ����� ���������� ��������
        door.Play();
        blackDoor.SetActive(true);

        timer = 0f;
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        Color color = sp.color;

        while (timer < 2f)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / 2f); // ��������� �����-����� �� 1 �� 0
            sp.color = color;
            yield return null;
        }
        color.a = 0f; // ��������� ���������� �����
        sp.color = color;
        door.Play();
        blackDoor.SetActive(false);

        timer = 0f;
        while (timer < 4f)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        door.Play();
        whiteDoor.SetActive(true);
        whiteDoor2.SetActive(true);
        effect.SetActive(true);

        timer = 0f;
        Transform _effect = effect.GetComponent<Transform>(); // �������� Transform �������
        Vector3 scale = _effect.localScale; // ���� ������� ������� �������
        lighrEffect.Play();

        while (timer < 2f)
        {
            timer += Time.deltaTime;
            scale += new Vector3(1f, 1f, 1f) * Time.deltaTime; // �������� ������� ����������
            _effect.localScale = scale; // ��������� ����� �������
            yield return null; // ��� �� ���������� �����
        }

        timer = 0f;
        while (timer < 2f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        dialogGolos.SetActive(true);
    }
}

