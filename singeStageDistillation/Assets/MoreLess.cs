using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreLess : MonoBehaviour
{
    public Manager manager;
    public bool allIconsVisible = false;

    public GameObject moreButton;
    public GameObject lessButton;
    public GameObject menuButton;
    public GameObject backButton;
    public GameObject fixPositionButton;
    public GameObject twoDthreeDButton;
    public GameObject panelVisibility;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMoreButtonClick()
    {
        allIconsVisible = true;
        SetIconVisibility(true);
        moreButton.SetActive(false);
        lessButton.SetActive(true);
    }

    public void onLessButtonClick()
    {
        allIconsVisible = false;
        SetIconVisibility(false);
        moreButton.SetActive(true);
        lessButton.SetActive(false);
    }

    public void SetIconVisibility(bool state)
    {
        menuButton.SetActive(state);
        backButton.SetActive(state);
        fixPositionButton.SetActive(state);
        twoDthreeDButton.SetActive(state);
        panelVisibility.SetActive(state);
    }
}
