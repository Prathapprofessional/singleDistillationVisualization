using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEffect : MonoBehaviour
{
    public ParticleSystem particleSystem;

    protected bool status = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        particleSystem.Play();
        status = true;
    }

    public void PlayIfNotPlaying()
    {
        if (!particleSystem.isPlaying)
        {
            status = true;
            particleSystem.Play();
        }
        
    }

    public void Pause()
    {
        if (particleSystem.isPlaying)
        {
            particleSystem.Pause();
        }
    }

    public void Resume()
    {
        if (status)
        {
            particleSystem.Play();
        }
    }

    public void Stop()
    {
        particleSystem.Play();
        particleSystem.Stop();
        status = false; 
    }

}
