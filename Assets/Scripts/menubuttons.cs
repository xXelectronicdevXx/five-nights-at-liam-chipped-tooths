using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menubuttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newgamebuttonpressed()
    {
        globalbars.coolypoo.latestunlockednight = 1;
        PlayerPrefs.SetInt("latestunlockednight", 1);
        globalbars.coolypoo.nighttoplay = 1;
        globalbars.coolypoo.hasbeaten420 = false;
        PlayerPrefs.SetInt("hasbeaten420", 0);
        SceneManager.LoadScene("newspaper");
    }

    public void continuebuttonpressed()
    {
        if (globalbars.coolypoo.latestunlockednight < 6)
        {
            globalbars.coolypoo.nighttoplay = globalbars.coolypoo.latestunlockednight;
        }
        else
        {
            globalbars.coolypoo.nighttoplay = 5;
        }
        SceneManager.LoadScene("nightintro");
    }

    public void sixthnightbuttonpressed()
    {
        globalbars.coolypoo.nighttoplay = 6;
        SceneManager.LoadScene("nightintro");
    }

    public void customnightbuttonpressed()
    {
        SceneManager.LoadScene("customnightmenu");
    }
}
