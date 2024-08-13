using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    static public bool isSoundOn = true;
    static AudioSource audioSource;
    public AudioClip[] AudioList;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = AudioList[0];
        audioSource.Play();
    }

    static public void SoundPlayer()
    {
        if(isSoundOn == false)
        {
            isSoundOn = true;
            audioSource.Play();
        }
        else if(isSoundOn == true)
        {
            isSoundOn = false;
            audioSource.Stop();
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    static public void SoundConverter()
    {
    
        audioSource.Play();
    }
}
