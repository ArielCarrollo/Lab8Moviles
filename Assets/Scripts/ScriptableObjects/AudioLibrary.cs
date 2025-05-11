using UnityEngine;

[CreateAssetMenu(menuName = "Resources/Audio Library")]
public class AudioLibrary : ScriptableObject
{
    [System.Serializable]
    public class SoundEntry
    {
        public string id;
        public AudioClip clip;
        [Range(0, 1)] public float defaultVolume = 1f;
    }

    [SerializeField] SoundEntry[] sounds;

    public AudioClip GetClip(string id)
    {
        foreach (var sound in sounds)
            if (sound.id == id) return sound.clip;
        return null;
    }

    public float GetDefaultVolume(string id)
    {
        foreach (var sound in sounds)
            if (sound.id == id) return sound.defaultVolume;
        return 1f;
    }
}