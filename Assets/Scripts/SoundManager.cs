using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource audSource;
    // Start is called before the first frame update
    void Start()
    {
        audSource = GetComponent<AudioSource>();
    }

    public void OneShot(AudioClip sound)
    {
        if(sound!=null)
            audSource.PlayOneShot(sound);

    }
}
