using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionScreen : IndividualScreen
{
    [SerializeField] private LevelSelectionController levelController;
    [SerializeField] private float delay;
    public override void ShowScreen()
    {
        base.ShowScreen();
        levelController.ShowChapter(delay);
    }

    public override void HideScreen()
    {
        base.HideScreen();
    }
}
