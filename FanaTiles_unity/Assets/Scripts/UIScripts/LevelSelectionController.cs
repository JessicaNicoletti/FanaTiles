using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelSelectionController : MonoBehaviour
{ 
    [SerializeField] private LevelCell[] levels;

    public IEnumerator ShowLevels(float _delay)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].ResetAnimation();
        }            

        yield return new WaitForSeconds(_delay);
        int totalLevels = 0;
        int columns = GetColumnCount();
       
        for (int i = 0; i < levels.Length; i++)
        {
            totalLevels++;

            levels[i].ShowCell(i+1);
            
            if (totalLevels >columns)
            {
                yield return new WaitForSeconds(0.05f);

                totalLevels = 0;
            }            
        }
    }

    //Get the number of columns of the grid layout group to set the animation;
    public int GetColumnCount()
    {
        int column = 0;
        for (int i = 1; i < levels.Length; i++)
        {
            if (levels[0].transform.position.y == levels[i].transform.position.y)            
                column++;            
            else            
                break;            
        }

        return column;
    }

    public void ShowChapter(float _delay)
    {
        StartCoroutine(ShowLevels(_delay));
    }
}
