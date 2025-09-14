using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public int sfxSourcesCount = 1;
    
    [Header("Slider")]
    public Slider bgmSlider;
    public Slider sfxSlider;
    
    [Range(0f, 1f)]
    public float bgmVolume = 1f;
    [Range(0f, 1f)]
    public float sfxVolume = 1f;
    
    [Header("SFX Clip")]
    public AudioClip[] sfxClips;
    #endregion
    
    public enum SFXType
    {
        End,
        Start,
        Imapact,
        Walk,
        Place,
        Btn,
        Win,
        ServingFood,
        Dizziness,
        MenuBtn,
        Skill,
        Sprint,
        Teleport
    }
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
            sfxSources = new AudioSource[sfxSourcesCount];
            for (int i = 0; i < sfxSourcesCount; i++)
            {
                sfxSources[i] = gameObject.AddComponent<AudioSource>();
            }
        }
        sfxClips = Resources.LoadAll<AudioClip>("SFX");
    }
    void Start()
    {
        bgmSource.volume = bgmSlider.value;
        foreach (var sfx in sfxSources)
            sfx.volume = sfxSlider.value;

        bgmVolume = bgmSlider.value;
        sfxVolume = sfxSlider.value;
        
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

    public void PlaySFX(SFXType type)
    {
        int index = (int)type;
        if (index < 0 || index >= sfxClips.Length)
        {
            return;
        }
        PlaySFX(sfxClips[index]);
    }
    
    #endregion
    
    
}
