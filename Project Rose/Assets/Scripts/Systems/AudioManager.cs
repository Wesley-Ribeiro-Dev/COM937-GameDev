using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioManagerInstance { get; private set; }
    [SerializeField] private Slider _audioSliderVolume;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipBG;
    [SerializeField] private AudioClip _audioClipMG;
    private void Awake()
    {
        if (AudioManagerInstance == null)
        {
            AudioManagerInstance = FindObjectOfType<AudioManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.buildIndex == 0)
        {
            _audioSource.clip = _audioClipBG;
            _audioSource.Play();
        }
        if (scene.buildIndex == 2)
        {
            _audioSource.clip = _audioClipMG;
            _audioSource.Play();
        }
    }
    
    private void OnSliderValueChanged()
    {
        _audioSource.volume = _audioSliderVolume.value;
    }

    public void SetVolumeSlider(Slider slider)
    {
        _audioSliderVolume = slider;
        _audioSliderVolume.onValueChanged.AddListener(delegate(float arg0) { OnSliderValueChanged(); });
    }
}
