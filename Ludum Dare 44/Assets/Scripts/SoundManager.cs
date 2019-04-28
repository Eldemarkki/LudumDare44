using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public SoundEffect[] sounds;

    private AudioSource source;

    public static SoundManager instance;
    
    private void Awake()
    {
        instance = this;
        
        source = GetComponent<AudioSource>();
    }

    public void Play(string soundName)
    {
        SoundEffect sound = sounds.First(s => s.name == soundName);
        
        source.PlayOneShot(sound.clip, sound.volume);
    }
}

[System.Serializable]
public struct SoundEffect
{
    public AudioClip clip;
    public float volume;
    public string name;
}
