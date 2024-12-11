using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // Ссылка на Audio Mixer
    [SerializeField] private Slider volumeSlider;  // Ссылка на UI Slider

    private const string VolumeKey = "MyExposedParam"; // Ключ для сохранения громкости

    void Start()
    {
        // Установить начальное значение громкости из PlayerPrefs
        if (PlayerPrefs.HasKey(VolumeKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumeKey); // Получаем сохранённое значение
            volumeSlider.value = savedVolume; // Применяем к слайдеру
            SetVolume(savedVolume); // Устанавливаем громкость
        }
        else
        {
            volumeSlider.value = 0.5f; // Значение по умолчанию
            SetVolume(0.5f);
        }

        // Подписка на изменения слайдера
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float sliderValue)
    {
        // Преобразование значения слайдера в громкость в дБ
        float dB = Mathf.Log10(sliderValue) * 20;

        // Устанавливаем минимальную громкость, чтобы избежать "максимума" при 0
        if (sliderValue <= 0.01f)
        {
            dB = -80f; // Полностью отключаем звук
        }

        // Устанавливаем громкость в Audio Mixer
        audioMixer.SetFloat("MyExposedParam", dB);

        // Сохраняем текущее значение слайдера
        PlayerPrefs.SetFloat(VolumeKey, sliderValue);
        PlayerPrefs.Save();
    }
}
