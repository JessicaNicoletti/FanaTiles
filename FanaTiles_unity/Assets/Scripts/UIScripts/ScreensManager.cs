using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    [SerializeField] IndividualScreen homeScreen;
    [SerializeField] IndividualScreen levelSelectionScreen;

    private IndividualScreen currentScreen;

    private void Start()
    {
        InitializeScreens();
    }

    //Delay time when switching beteewn screens;
    private IEnumerator DelaySwitchScreen(IndividualScreen _screen,float _time)
    {
        currentScreen?.HideScreen();
        yield return new WaitForSeconds(_time);
        SwitchScreen(_screen);
    }

    public void InitializeScreens()
    {
        homeScreen.InitializeScreen();
        levelSelectionScreen.InitializeScreen();

        //Start home screen;
        StartCoroutine(DelaySwitchScreen(homeScreen, 0.5f));
    }

    public void SwitchScreen(IndividualScreen _newScreen)
    {        
        _newScreen.ShowScreen();
        currentScreen = _newScreen;
    }

    #region OnClick Methods

    public void OnClick_HomeScreen()
    {
        StartCoroutine(DelaySwitchScreen(homeScreen, 0.8f));
    }

    public void OnClick_LevelSelectionScreen()
    {
        StartCoroutine(DelaySwitchScreen(levelSelectionScreen,0.8f));
    }

    #endregion
}
