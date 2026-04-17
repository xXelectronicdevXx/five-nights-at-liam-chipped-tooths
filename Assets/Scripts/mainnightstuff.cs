using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainnightstuff : MonoBehaviour
{
    public TextMeshProUGUI powerleft;
    public TextMeshProUGUI powerusage;
    public TextMeshProUGUI nightnumber;
    public int night = 1;
    public bool powerdown = false;
    public int power = 999;
    private int usage = 1;
    public buttons buttons;
    public List<string> thingsusingpower = new List<string>();
    //poweroutage
    [Space]
    [Space]
    public GameObject dcfhandler;
    public GameObject laehandler;
    public GameObject lcthandler;
    public GameObject csfhandler;
    public AudioSource powerdownsound;
    public AudioSource fansound;
    public AudioSource honk;
    public AudioSource musicbox;
    public GameObject uitodisablewhenpowergoesout;
    public Renderer leftlightrenderer;
    public Renderer rightlightrenderer;
    public Renderer leftdoorrenderer;
    public Renderer rightdoorrenderer;
    public Material lightoffmat;
    public Material dooroffmat;
    public fan Fan;
    public doorbutton leftdoorscript;
    public doorbutton rightdoorscript;
    public lightbutton leftlightscript;
    public lightbutton rightlightscript;
    public GameObject feddyeyes;
    public GameObject powerofflight;
    public GameObject poweronlight;
    public GameObject dcflocations;
    public GameObject jumpscarey;
    public AudioSource easteregg1;
    public AudioSource easteregg2;
    // Start is called before the first frame update
    void Start()
    {
        thingsusingpower.Add("literalair");
        StartCoroutine(Powerdrain());
        StartCoroutine(Passivepowerdrain());
    }

    void Awake()
    {
        night = globalbars.coolypoo.nighttoplay;
        nightnumber.text = "Night " + night.ToString();
    }

    int betterrandom(int min, int max)
    {
        return Random.Range(min, max + 1);
    }

    void gameoverscreen()
    {
        SceneManager.LoadScene("lost");
    }

    private IEnumerator lerpyboi(Vector3 targetpos, float duration)
    {
        Vector3 startpos = jumpscarey.transform.position;
        float elapsedtime = 0f;
        while (elapsedtime < duration)
        {
            float t = elapsedtime / duration;
            t = Mathf.Clamp01(t);
            jumpscarey.transform.position = Vector3.Lerp(startpos, targetpos, t);
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        jumpscarey.transform.position = targetpos;
    }

    public void jumpscare()
    {
        jumpscarey.SetActive(true);
        StartCoroutine(lerpyboi(new Vector3(-0.00499999989f, 1f, -7.1420002f), 0.601f));
        Invoke("gameoverscreen", 0.601f);
    }

    IEnumerator phase1()
    {
        int attempts = 0;
        while (true)
        {
            yield return new WaitForSeconds(5f);
            int randomnum = betterrandom(1, 5);
            if (randomnum == 1)
            {
                StartCoroutine(flickeryeyes());
                StartCoroutine(phase2());
                yield break;
            }
            else
            {
                attempts++;
                Debug.Log(attempts.ToString());
                if (attempts == 4)
                {
                    StartCoroutine(flickeryeyes());
                    StartCoroutine(phase2());
                    yield break;
                }
            }
        }
    }

    IEnumerator phase2()
    {
        int attempts = 0;
        musicbox.Play();
        while (true)
        {
            yield return new WaitForSeconds(5f);
            int randomnum = betterrandom(1, 5);
            if (randomnum == 1)
            {
                StopAllCoroutines();
                StartCoroutine(phase3());
                yield break;
            }
            else
            {
                attempts++;
                Debug.Log(attempts.ToString());
                if (attempts == 4)
                {
                    StopAllCoroutines();
                    StartCoroutine(phase3());
                    yield break;
                }
            }
        }
    }

    IEnumerator phase3()
    {
        int attempts = 0;
        feddyeyes.SetActive(false);
        musicbox.Stop();
        powerofflight.SetActive(false);
        while (true)
        {
            yield return new WaitForSeconds(2f);
            int randomnum = betterrandom(1, 5);
            if (randomnum == 1)
            {
                jumpscare();
                yield break;
            }
            else
            {
                attempts++;
                Debug.Log(attempts.ToString());
                if (attempts == 10)
                {
                    jumpscare();
                    yield break;
                }
            }
        }
    }


    IEnumerator flickeryeyes()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.05f);
            int randomnum = betterrandom(1, 4);
            if (randomnum == 1)
            {
                feddyeyes.SetActive(true);
            }
            else if (randomnum >= 2)
            {
                feddyeyes.SetActive(false);
            }
        }
    }

    IEnumerator Passivepowerdrain()
    {
        while(true)
        {
            if (night == 1)
            {
                yield break;
            }
            if (night == 2)
            {
                yield return new WaitForSeconds(6);
                power -= 1;
            }
            else if (night == 3)
            {
                yield return new WaitForSeconds(5);
                power -= 1;
            }
            else if (night == 4)
            {
                yield return new WaitForSeconds(4);
                power -= 1;
            }
            else if (night > 4)
            {
                yield return new WaitForSeconds(3);
                power -= 1;
            }
        }
    }

    IEnumerator Powerdrain()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            power -= usage;
            powerleft.text = "Power left: " + (power / 10).ToString() + "%";
            if(power <= 0)
            {
                powercooked();
                yield break;
            }
        }
    }

    void powercooked()
    {
        powerdown = true;
        easteregg1.Stop();
        easteregg2.Stop();
        StopAllCoroutines();
        powerdownsound.Play();
        laehandler.SetActive(false);
        dcfhandler.SetActive(false);
        lcthandler.SetActive(false);
        csfhandler.SetActive(false);
        Fan.enabled = false;
        fansound.enabled = false;
        honk.enabled = false;
        uitodisablewhenpowergoesout.SetActive(false);
        if (buttons.camsopen == true)
        {
            buttons.forcecamsdown();
        }
        buttons.enabled = false;
        if(leftdoorscript.doorstate == "closed" || leftdoorscript.doorstate == "closing")
        {
            leftdoorscript.forcedooropen();
        }
        if (rightdoorscript.doorstate == "closed" || rightdoorscript.doorstate == "closing")
        {
            rightdoorscript.forcedooropen();
        }
        if (leftlightscript.lightstate == "on")
        {
            leftlightscript.turnlightoff();
        }
        if (rightlightscript.lightstate == "on")
        {
            rightlightscript.turnlightoff();
        }
        poweronlight.SetActive(false);
        powerofflight.SetActive(true);
        leftdoorrenderer.material = dooroffmat;
        rightdoorrenderer.material = dooroffmat;
        leftlightrenderer.material = lightoffmat;
        rightlightrenderer.material = lightoffmat;
        foreach (Transform gamer in dcflocations.transform)
        {
            gamer.gameObject.SetActive(false);
        }
        StartCoroutine(phase1());
    }

    // Update is called once per frame
    void Update()
    {
        if(powerdown == false)
        {
            usage = thingsusingpower.Count;
            powerusage.text = "Usage: " + usage.ToString();
            if (leftdoorscript.doorstate == "closed")
            {
                if (!thingsusingpower.Contains("leftdoor"))
                {
                    thingsusingpower.Add("leftdoor");
                }
            }
            else
            {
                if (thingsusingpower.Contains("leftdoor"))
                {
                    thingsusingpower.Remove("leftdoor");
                }
            }
            if (rightdoorscript.doorstate == "closed")
            {
                if (!thingsusingpower.Contains("rightdoor"))
                {
                    thingsusingpower.Add("rightdoor");
                }
            }
            else
            {
                if (thingsusingpower.Contains("rightdoor"))
                {
                    thingsusingpower.Remove("rightdoor");
                }
            }
            if (leftlightscript.lightstate == "on")
            {
                if (!thingsusingpower.Contains("leftlight"))
                {
                    thingsusingpower.Add("leftlight");
                }
            }
            else
            {
                if (thingsusingpower.Contains("leftlight"))
                {
                    thingsusingpower.Remove("leftlight");
                }
            }
            if (rightlightscript.lightstate == "on")
            {
                if (!thingsusingpower.Contains("rightlight"))
                {
                    thingsusingpower.Add("rightlight");
                }
            }
            else
            {
                if (thingsusingpower.Contains("rightlight"))
                {
                    thingsusingpower.Remove("rightlight");
                }
            }
            if (buttons.camsopen == true)
            {
                if (!thingsusingpower.Contains("cams"))
                {
                    thingsusingpower.Add("cams");
                }
            }
            else
            {
                if (thingsusingpower.Contains("cams"))
                {
                    thingsusingpower.Remove("cams");
                }
            }
        }
        
    }
}
