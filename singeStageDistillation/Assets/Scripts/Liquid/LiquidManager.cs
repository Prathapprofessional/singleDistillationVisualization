using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidManager : MonoBehaviour
{
    public InputLiquid inputLiquid;
    public OutputLiquid outputLiquid;
    public CondenserLiquid condenserLiquid;
    public ThermometerLiquid thermometerLiquid; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlayPauseResumeButtonPressed()
    {
        if (!Manager.GetStartedStatus()) //Play
        {
            inputLiquid.BoilUnboilLiquid(true, true);
        }
        else if (Manager.GetStartedStatus() & Manager.GetPlayingStatus()) //Pause
        {
            inputLiquid.BoilUnboilLiquid(false, true);
        }
        else if (Manager.GetStartedStatus() & !Manager.GetPlayingStatus()) //Resume 
        {
            inputLiquid.BoilUnboilLiquid(true, true);
        }

        condenserLiquid.SetFillLiquidConditions();
        thermometerLiquid.SetFillLiquidConditions();
    }

    public void onStopButtonPressed()
    {
        inputLiquid.BoilUnboilLiquid(false, false);
        inputLiquid.SetOriginalLevel(); 
        condenserLiquid.SetEmptyLiquidConditions();
        outputLiquid.SetEmptyLiquidConditions();
        thermometerLiquid.SetEmptyLiquidConditions();
    }

    public void onSkipButtonPressed()
    {

    }

    public void onRestartButtonPressed()
    {

    }
}
