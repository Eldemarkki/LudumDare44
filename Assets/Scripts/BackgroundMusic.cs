using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    public AudioClip song;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource src = GetComponent<AudioSource>();

        src.clip = song;
        src.loop = true;
        
        src.Play();   
    }
}
