using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animation Entity Class - Every animation effect is derived from this class 
/// Derived from this class is automatically played, paused and resumed when necessary 
/// </summary>
public class AnimationEffect : MonoBehaviour
{
    /// <summary>
    /// Particle system representing the animation 
    /// </summary>
    public ParticleSystem particleSystem;

    /// <summary>
    /// Global singleton manager  
    /// </summary>
    public Manager manager;

    //To control the particles according to the data 
    public int minEmission = 0;
    public int maxEmission = 0;
    public int minParticles = 0;
    public int maxParticles = 0;

    /// <summary>
    /// Bool value to state whether animation is playing or not 
    /// </summary>
    protected bool status = false;


    /// <summary>
    /// Play the Effect 
    /// </summary>
    public void Play()
    {
        particleSystem.Play();
        status = true;
    }

    /// <summary>
    /// Play the Effect only if not playing 
    /// </summary>
    public void PlayIfNotPlaying()
    {
        if (!particleSystem.isPlaying)
        {
            status = true;
            particleSystem.Play();
        }
        
    }

    /// <summary>
    /// Pause the Effect 
    /// </summary>
    public void Pause()
    {
        if (particleSystem.isPlaying)
        {
            particleSystem.Pause();
        }
    }

    /// <summary>
    /// Resume the Effect 
    /// </summary>
    public void Resume()
    {
        if (status)
        {
            particleSystem.Play();
        }
    }

    /// <summary>
    /// Stop the Effect 
    /// </summary>
    public void Stop()
    {
        particleSystem.Play();
        particleSystem.Stop();
        status = false; 
    }

    /// <summary>
    /// Set size according to the data 
    /// </summary>
    public virtual void SetAmountAccordingToData(int index)
    {

    }
}
