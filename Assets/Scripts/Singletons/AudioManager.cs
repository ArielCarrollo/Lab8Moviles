using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : SingletonPersistent<AudioManager>
{
    [Header("Mixer Parameters")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] string masterVolumeParam = "MasterVolume";
    [SerializeField] string musicVolumeParam = "MusicVolume";
    [SerializeField] string sfxVolumeParam = "SFXVolume";

    [Header("Events - Publisher")]
    [SerializeField] GameEventFloat onMasterVolumeChanged; // ScriptableObject
    [SerializeField] GameEventFloat onMusicVolumeChanged;
    [SerializeField] GameEventFloat onSFXVolumeChanged;

    const float MIN_VOLUME = 0.0001f;
    const float MAX_VOLUME = 1f;

    public override void Awake()
    {
        base.Awake();
        LoadAllVolumes();
    }

    public void SetMasterVolume(float volume) => SetVolume(volume, masterVolumeParam, onMasterVolumeChanged);
    public void SetMusicVolume(float volume) => SetVolume(volume, musicVolumeParam, onMusicVolumeChanged);
    public void SetSFXVolume(float volume) => SetVolume(volume, sfxVolumeParam, onSFXVolumeChanged);

    private void SetVolume(float volume, string mixerParam, GameEventFloat volumeEvent)
    {
        volume = Mathf.Clamp(volume, MIN_VOLUME, MAX_VOLUME);
        float dB = volume > MIN_VOLUME ? Mathf.Log10(volume) * 20 : -80f;

        audioMixer.SetFloat(mixerParam, dB);
        PlayerPrefs.SetFloat(mixerParam, volume);
        volumeEvent.Raise(volume); // Notifica a los suscriptores
    }

    private void LoadAllVolumes()
    {
        SetMasterVolume(PlayerPrefs.GetFloat(masterVolumeParam, MAX_VOLUME));
        SetMusicVolume(PlayerPrefs.GetFloat(musicVolumeParam, MAX_VOLUME));
        SetSFXVolume(PlayerPrefs.GetFloat(sfxVolumeParam, MAX_VOLUME));
    }
}