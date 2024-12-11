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

    private bool isMoving = false; // Флаг для проверки, движется ли объект

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
        isMoving = true; // Устанавливаем флаг, чтобы предотвратить повторный запуск
        IsWalking = true;

        walk.Play();
        float timer = 0f;
        while (timer < 3f)
        {
            timer += Time.deltaTime;
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            // Установить поворот влево, сохраняя текущие y и z
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            yield return null;
        }
        walk.Stop();

        IsWalking = false;
        IsDialogEnd = false;
        isMoving = false; // Сбрасываем флаг после завершения движения
        door.Play();
        blackDoor.SetActive(true);

        timer = 0f;
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        Color color = sp.color;

        while (timer < 2f)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / 2f); // Уменьшаем альфа-канал от 1 до 0
            sp.color = color;
            yield return null;
        }
        color.a = 0f; // Полностью прозрачный экран
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
        Transform _effect = effect.GetComponent<Transform>(); // Получаем Transform объекта
        Vector3 scale = _effect.localScale; // Берём текущий масштаб объекта
        lighrEffect.Play();

        while (timer < 2f)
        {
            timer += Time.deltaTime;
            scale += new Vector3(1f, 1f, 1f) * Time.deltaTime; // Изменяем масштаб постепенно
            _effect.localScale = scale; // Применяем новый масштаб
            yield return null; // Ждём до следующего кадра
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

