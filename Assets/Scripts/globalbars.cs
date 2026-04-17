using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalbars : MonoBehaviour
{
    public static globalbars coolypoo;
    public int latestunlockednight = 1;
    public int nighttoplay;
    public bool hasbeaten420 = false;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject sixthnightbutton;
    public GameObject customnightbutton;
    // Start is called before the first frame update
    void Awake()
    {
        setpponlyifnoexist("latestunlockednight", 1);
        setpponlyifnoexist("hasbeaten420", 0);
        hasbeaten420 = PlayerPrefs.GetInt("hasbeaten420") == 1;
        latestunlockednight = PlayerPrefs.GetInt("latestunlockednight");
        if (coolypoo == null)
        {
            coolypoo = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if(latestunlockednight >= 6)
        {
            star1.SetActive(true);
            sixthnightbutton.SetActive(true);
        }
        if (latestunlockednight == 7)
        {
            star2.SetActive(true);
            customnightbutton.SetActive(true);
        }
        if(hasbeaten420 == true)
        {
            star3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setpponlyifnoexist(string name, int value)
    {
        if(!PlayerPrefs.HasKey(name))
        {
            PlayerPrefs.SetInt(name, value);
        }
    }
}
