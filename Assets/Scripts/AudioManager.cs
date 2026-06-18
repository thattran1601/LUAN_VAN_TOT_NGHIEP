using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public float VolumeMusic = 1f;
    public float VolumeSFX = 1f;

    public AudioClip MainMenuSource;
    public AudioClip LobbySource;
    public AudioClip Map1Source;
    public AudioClip Map2Source;
    public AudioClip Map3Source;

    [Header("SFX")]
    public AudioClip ButtonClick;
    public AudioClip Hit;
    public AudioClip Arrow;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }   
        else
        {
            Destroy(gameObject);
        }    
    }

    void Start()
    {
        VolumeMusic = PlayerPrefs.GetFloat("MusicVolume", 1f);
        VolumeSFX = PlayerPrefs.GetFloat("SFXVolume", 1f);

        bgmSource.volume = VolumeMusic;
        sfxSource.volume = VolumeSFX;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBMG(AudioClip clip)
    {
        if (clip == null)
            return;
        if (bgmSource.clip == clip && bgmSource.isPlaying) return;
        StopBMG();
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.volume = VolumeMusic;
        bgmSource.Play();
    }    
    public void StopBMG()
    {
        bgmSource.Stop();
    }  
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null)
            return;
        sfxSource.volume = VolumeSFX;
        sfxSource.PlayOneShot(clip);
    }
    public void SetMusicVolume(float value)
    {
        VolumeMusic = value;
        bgmSource.volume = VolumeMusic;
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        VolumeSFX = value;
        sfxSource.volume = VolumeSFX;
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
        
    }

}
