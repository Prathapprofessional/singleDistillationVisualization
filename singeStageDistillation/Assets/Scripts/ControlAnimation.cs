using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimation : MonoBehaviour
{
    private bool flameOn = false;
    public ParticleSystem flameParticleSystem;
    public ParticleSystem dropletParticleSystem;
    public ParticleSystem vapourVesselParticleSystem;
    public ParticleSystem vapourVesselTopParticleSystem;
    public ParticleSystem bubblesParticleSystem;
    public OutputLiquid outputLiquid; 

    public Renderer renderInputLiquid;
    public Renderer renderOutputLiquid;
    public Renderer vapourVesselShader;
    public Renderer vapourVesselTopShader;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartStopAnimation()
    {
        if (flameOn)
        {

            renderInputLiquid.material.SetColor("_Tint", Color.blue);
            renderOutputLiquid.material.SetColor("_Tint", Color.green);
            vapourVesselShader.material.SetColor("_TintColor", Color.blue);
            vapourVesselTopShader.material.SetColor("_TintColor", Color.blue);

            CancelInvoke("playBubbles");
            CancelInvoke("playVapourVessel");
            CancelInvoke("playVapourVesselTop");
            CancelInvoke("playDroplets");
            CancelInvoke("startOutputLiquidAnimation");
            CancelInvoke("changeColour");

            flameParticleSystem.Stop();
            dropletParticleSystem.Stop();
            vapourVesselParticleSystem.Stop();
            vapourVesselTopParticleSystem.Stop();
            bubblesParticleSystem.Stop();
            flameOn = false;
        }
        else
        {
            flameOn = true;
            flameParticleSystem.Play();
            Invoke("playBubbles", 3);
            Invoke("playVapourVessel", 6);
            Invoke("playVapourVesselTop", 9);
            Invoke("playDroplets", 12);
            Invoke("startOutputLiquidAnimation", 13);
            Invoke("changeColour", 25);
        }       
    }

    void playBubbles()
    {
        bubblesParticleSystem.Play(); 
    }

    void playVapourVessel()
    {
        vapourVesselParticleSystem.Play();
    }

    void playVapourVesselTop()
    {
        vapourVesselTopParticleSystem.Play();
    }

    void playDroplets()
    {
        dropletParticleSystem.Play();
    }

    void startOutputLiquidAnimation()
    {
        outputLiquid.FillOutputLiquid(); 
    }

    void changeColour()
    {
        renderInputLiquid.material.SetColor("_Tint", Color.red);
        renderOutputLiquid.material.SetColor("_Tint", Color.magenta);
        vapourVesselShader.material.SetColor("_TintColor", Color.red);
        vapourVesselTopShader.material.SetColor("_TintColor", Color.red);
    }
}
