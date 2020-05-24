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
    public ParticleSystem vapourVesselCondenserParticleSystem;
    public ParticleSystem bubblesParticleSystem;

    public Renderer vapourVesselShader;
    public Renderer vapourVesselTopShader;
    public Renderer vapourVesselCondenserShader;
    public Renderer dropletShader;
    public Renderer splashShader;

    public OutputLiquid outputLiquid;
    public InputLiquid inputLiquid;
    public ProcessDetail processDetail; 

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
            //processDetail.setAllDetailsBlank(); 
            inputLiquid.changeTexture("blue");
            outputLiquid.changeTexture("blue");
            vapourVesselShader.material.SetColor("_TintColor", Color.green);
            vapourVesselTopShader.material.SetColor("_TintColor", Color.green);
            vapourVesselCondenserShader.material.SetColor("_TintColor", Color.green);
            dropletShader.material.SetColor("_TintColor", Color.green);
            splashShader.material.SetColor("_TintColor", Color.green);

            CancelInvoke("Heating");
            inputLiquid.BoilLiquid(false);
            CancelInvoke("Boiling");
            CancelInvoke("Vapourization");
            CancelInvoke("VapourMoving");
            CancelInvoke("Condensation");
            CancelInvoke("EthanolFlowing");
            CancelInvoke("startOutputLiquidAnimation");
            CancelInvoke("MethanolFlowing");

            flameParticleSystem.Stop();
            dropletParticleSystem.Stop();
            vapourVesselParticleSystem.Stop();
            vapourVesselTopParticleSystem.Stop();
            vapourVesselCondenserParticleSystem.Stop();
            bubblesParticleSystem.Stop();
            flameOn = false;
        }
        else
        {
            flameOn = true;
            flameParticleSystem.Play();
            //processDetail.setInputLiquidName("White Wine"); 
            StartCoroutine(startProcessAt("010", 3f, "Heating"));
        }       
    }

    IEnumerator startProcessAt(string time, float timeToWait, string processName)
    {
        yield return new WaitForSeconds(timeToWait);

        if (flameOn)
        {
            //processDetail.setTime(time, processName);

            switch (processName)
            {
                case "Heating":
                    Invoke("Heating", 1);
                    StartCoroutine(startProcessAt("015", 6f, "Boiling"));
                    break;
                case "Boiling":
                    Invoke("Boiling", 1);
                    StartCoroutine(startProcessAt("020", 6f, "Vapourization"));
                    break;
                case "Vapourization":
                    Invoke("Vapourization", 1);
                    StartCoroutine(startProcessAt("030", 6f, "VapourMoving"));
                    break;
                case "VapourMoving":
                    Invoke("VapourMoving", 1);
                    Invoke("ReduceInputLiquid", 2); 
                    StartCoroutine(startProcessAt("035", 6f, "Condensation"));
                    break;
                case "Condensation":
                    Invoke("Condensation", 1);
                    StartCoroutine(startProcessAt("040", 6f, "EthanolFlowing"));
                    break;
                case "EthanolFlowing":
                    Invoke("EthanolFlowing", 1);
                    Invoke("startOutputLiquidAnimation", 2);
                    StartCoroutine(startProcessAt("080", 10f, "MethanolFlowing"));
                    break;
                case "MethanolFlowing":
                    Invoke("emptyOutputLiquidCompletely", 1);
                    Invoke("MethanolFlowing", 1);
                    StartCoroutine(startProcessAt("150", 5f, ""));
                    break;
                default:
                    break;
            }
        }
    }

    void Heating()
    {
        inputLiquid.BoilLiquid(true); 
    }

    void Boiling()
    {
        bubblesParticleSystem.Play(); 
    }

    void Vapourization()
    {
        vapourVesselParticleSystem.Play();
    }

    void ReduceInputLiquid()
    {
        inputLiquid.StartReducingLiquid(); 
    }

    void VapourMoving()
    {
        vapourVesselTopParticleSystem.Play();
    }

    void Condensation()
    {
        vapourVesselCondenserParticleSystem.Play();
    }

    void EthanolFlowing()
    {
        dropletParticleSystem.Play();
    }

    void startOutputLiquidAnimation()
    {
        outputLiquid.FillOutputLiquid(); 
    }

    void emptyOutputLiquidCompletely()
    {
        outputLiquid.EmptyOutCompletely();
    }

    void MethanolFlowing()
    {
        inputLiquid.changeTexture("red"); 
        outputLiquid.changeTexture("red");
        vapourVesselShader.material.SetColor("_TintColor", Color.red);
        vapourVesselTopShader.material.SetColor("_TintColor", Color.red);
        vapourVesselCondenserShader.material.SetColor("_TintColor", Color.red);
        dropletShader.material.SetColor("_TintColor", Color.red);
        splashShader.material.SetColor("_TintColor", Color.red);
    }
}
