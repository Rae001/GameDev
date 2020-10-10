using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Button[] lvButtons;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < lvButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                lvButtons[i].interactable = false;
            }
        }
    }

}
