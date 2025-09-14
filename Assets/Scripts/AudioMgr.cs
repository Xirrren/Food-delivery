using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioMgr : MonoBehaviour
{
    public static AudioMgr Instance { get; private set; }
    
    #region 
    [Header("BGM")]
    public AudioSource bgmSource;

    [Header("SFX")]
    public AudioSource[] sfxSources;
    
    [Header("UI 音量控制")]
    public Slider bgmSlider;
    public Slider sfxSlider;
    
    [Range(0f, 1f)]
    public float bgmVolume = 1f;
    [Range(0f, 1f)]
    public float sfxVolume = 1f;
    #endregion
    void Awake()
    {
        Instance = this;
        if (bgmSource == null)
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
            bgmSource.loop = true;
        }

        if (sfxSources == null || sfxSources.Length == 0)
        {
            sfxSources = new AudioSource[3];
            for (int i = 0; i < sfxSources.Length; i++)
            {
                sfxSources[i] = gameObject.AddComponent<AudioSource>();
            }
        }
    }
    void Start()
    {
        bgmSource.volume = bgmSlider.value;
        foreach (var sfx in sfxSources)
            sfx.volume = sfxSlider.value;

        bgmSlider.onValueChanged.AddListener(value =>
        {
            bgmSource.volume = value;
        });

        sfxSlider.onValueChanged.AddListener(value =>
        {
            foreach (var sfx in sfxSources)
                sfx.volume = value;
        });
    }
    
    #region BGM
    public void PlayBGM(AudioClip clip)
    {
        if (clip == null) return;
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }
    #endregion
    
    #region SFX
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        foreach (var sfx in sfxSources)
        {
            if (!sfx.isPlaying)
            {
                sfx.PlayOneShot(clip);
                return;
            }
        }
        sfxSources[0].PlayOneShot(clip);
    }
    #endregion
    
}
