using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip music;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source.clip = music;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
