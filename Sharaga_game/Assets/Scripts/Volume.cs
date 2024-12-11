using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // ������ �� Audio Mixer
    [SerializeField] private Slider volumeSlider;  // ������ �� UI Slider

    private const string VolumeKey = "MyExposedParam"; // ���� ��� ���������� ���������

    void Start()
    {
        // ���������� ��������� �������� ��������� �� PlayerPrefs
        if (PlayerPrefs.HasKey(VolumeKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumeKey); // �������� ���������� ��������
            volumeSlider.value = savedVolume; // ��������� � ��������
            SetVolume(savedVolume); // ������������� ���������
        }
        else
        {
            volumeSlider.value = 0.5f; // �������� �� ���������
            SetVolume(0.5f);
        }

        // �������� �� ��������� ��������
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float sliderValue)
    {
        // �������������� �������� �������� � ��������� � ��
        float dB = Mathf.Log10(sliderValue) * 20;

        // ������������� ����������� ���������, ����� �������� "���������" ��� 0
        if (sliderValue <= 0.01f)
        {
            dB = -80f; // ��������� ��������� ����
        }

        // ������������� ��������� � Audio Mixer
        audioMixer.SetFloat("MyExposedParam", dB);

        // ��������� ������� �������� ��������
        PlayerPrefs.SetFloat(VolumeKey, sliderValue);
        PlayerPrefs.Save();
    }
}
