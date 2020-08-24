using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private SoundPlayer soundplayer;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = audioClips[1];
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
