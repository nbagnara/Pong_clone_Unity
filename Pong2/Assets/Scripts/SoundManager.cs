using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //store sound effects
    //an example of a singleton
    public static SoundManager Instance = null;//I guess this protects from creating diff instances of this class

    //naming them here so can drag audio files into SoundManager GameObj.
    public AudioClip goalBloop;
    public AudioClip lossBuzz;
    public AudioClip hitPaddleBloop;
    public AudioClip winSound;
    public AudioClip wallBloop;

    private AudioSource soundEffectAudio;

    // Use this for initialization
    void Start ()
    {
        //setting up so there can be no other instance pt2
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        AudioSource[] sources = GetComponents<AudioSource>();//creates an array to hold audiosources

        foreach (AudioSource source in sources)
        {
            if (source.clip == null)
            {
                soundEffectAudio = source; //creates instances of AudioSource soundEffectAudio and puts them in the array
            }
        }
	}
	
	//allows any other gameobj to call sound manager to play a sound
    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
