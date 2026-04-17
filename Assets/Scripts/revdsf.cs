using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class revdsf : MonoBehaviour
{
    public TextMeshProUGUI nightting;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gotogame());
    }

    void Awake()
    {
        if (globalbars.coolypoo.nighttoplay == 1)
        {
            nightting.text = "1st Night";
        }
        else if (globalbars.coolypoo.nighttoplay == 2)
        {
            nightting.text = "2nd Night";
        }
        else if (globalbars.coolypoo.nighttoplay == 3)
        {
            nightting.text = "3rd Night";
        }
        else if (globalbars.coolypoo.nighttoplay >= 4)
        {
            nightting.text = globalbars.coolypoo.nighttoplay.ToString() + "th Night";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator gotogame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Game");
    }
}
