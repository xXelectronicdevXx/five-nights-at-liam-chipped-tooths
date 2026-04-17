using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sixamscreen : MonoBehaviour
{
    public Transform thingamajiggy;
    public Transform thingamajiggy2;
    public AudioSource yayyyyy;
    // Start is called before the first frame update
    void Start()
    {
        if (globalbars.coolypoo.latestunlockednight != 7)
        {
            globalbars.coolypoo.latestunlockednight += 1;
            PlayerPrefs.SetInt("latestunlockednight", globalbars.coolypoo.latestunlockednight);
        }
        if(customnightstuff.coolypoo2 != null)
        {
            if(customnightstuff.coolypoo2.lctlevel == 20 && customnightstuff.coolypoo2.dcflevel == 20 && customnightstuff.coolypoo2.laelevel == 20 && customnightstuff.coolypoo2.csflevel == 20)
            {
                globalbars.coolypoo.hasbeaten420 = true; 
                PlayerPrefs.SetInt("hasbeaten420", 1);
            }
        }
        PlayerPrefs.Save();
        StartCoroutine(Ienumeratorception());
        StartCoroutine(skibidi());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Ienumeratorception()
    {
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(lerpyboi(thingamajiggy2.position, 4.5f));
    }

    private IEnumerator skibidi()
    {
        yield return new WaitForSeconds(10f);
        if(globalbars.coolypoo.latestunlockednight < 6)
        {
            globalbars.coolypoo.nighttoplay = globalbars.coolypoo.latestunlockednight;
            SceneManager.LoadScene("nightintro");
        }
        else if(globalbars.coolypoo.latestunlockednight >= 6)
        {
            if(globalbars.coolypoo.nighttoplay == 5)
            {
                SceneManager.LoadScene("ending");
            }
            else if (globalbars.coolypoo.nighttoplay == 6)
            {
                SceneManager.LoadScene("ending6thnight");
            }
            else if (globalbars.coolypoo.nighttoplay == 7)
            {
                SceneManager.LoadScene("endingcustomnight");
            }
        }
    }

    private IEnumerator lerpyboi(Vector3 targetpos, float duration)
    {
        Vector3 startpos = thingamajiggy.position;
        float elapsedtime = 0f;
        while (elapsedtime < duration)
        {
            float t = elapsedtime / duration;
            t = Mathf.Clamp01(t);
            thingamajiggy.position = Vector3.Lerp(startpos, targetpos, t);
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        thingamajiggy.position = targetpos;
        yayyyyy.Play();
    }
}
