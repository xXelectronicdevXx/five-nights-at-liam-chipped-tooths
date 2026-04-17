using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class LiamAsianEye : MonoBehaviour
{
    public int ailevel = 20;
    public GameObject laelocations;
    public string laelocation = "cam1a";
    private string prevlaelocation = "";
    public AudioSource kitchenbanging;
    public GameObject cam6;
    public GameObject jumpscarey;
    // for disabled when theres a jumpscare
    public buttons cameras;
    public DjCrazyFace dcf;
    public LiamChippedTooth lct;
    public ColinSquishedFace csf;
    public doorbutton leftdoor;
    public doorbutton rightdoor;
    public lightbutton leftlight;
    public lightbutton rightlight;
    public mainnightstuff mns;
    public bool laewantstoattack = false;
    public GameObject thingies;
    // Start is called before the first frame update
    void Start()
    {
        if (mns.night == 1)
        {
            ailevel = 0;
        }
        else if (mns.night == 2)
        {
            ailevel = 1;
        }
        else if (mns.night == 3)
        {
            ailevel = 5;
        }
        else if (mns.night == 4)
        {
            ailevel = 4;
        }
        else if (mns.night == 5)
        {
            ailevel = 7;
        }
        else if (mns.night == 6)
        {
            ailevel = 12;
        }
        else if (mns.night == 7)
        {
            var data = customnightstuff.coolypoo2;

            ailevel = data.laelevel;
        }
        StartCoroutine(Movement());
    }

    int betterrandom(int min, int max)
    {
        return Random.Range(min, max + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(cameras.lastopenedcameraobject == cam6 && cameras.camsopen == true)
        {
            kitchenbanging.volume = 1f;
        }
        else
        {
            kitchenbanging.volume = 0f;
        }
    }

    IEnumerator Movement()
    {
        while(true)
        {
            yield return new WaitForSeconds(4.98f);
            trytomove();
        }
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
    void gameoverscreen()
    {
        SceneManager.LoadScene("lost");
    }

    public void jumpscare()
    {
        thingies.SetActive(false);
        cameras.enabled = false;
        dcf.enabled = false;
        csf.enabled = false;
        lct.enabled = false;
        leftdoor.enabled = false;
        rightdoor.enabled = false;
        leftlight.enabled = false;
        rightlight.enabled = false;
        mns.enabled = false;
        jumpscarey.SetActive(true);
        foreach (Transform gamer in laelocations.transform)
        {
            gamer.gameObject.SetActive(false);
        }
        StartCoroutine(lerpyboi(new Vector3(-0.00499999989f, 1f, -7.1420002f), 1.202f));
        Invoke("gameoverscreen", 1.202f);
    }

    public void trytomove()
    {
        int randomnum = betterrandom(1, 20);
        if (ailevel >= randomnum)
        {
            if (laelocation == "cam1a")
            {
                prevlaelocation = laelocation;
                laelocation = "cam1b";
                if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                {
                    cameras.camscookedtime = 5f;
                }
                foreach (Transform gamer in laelocations.transform)
                {
                    if (!gamer.gameObject.name.Contains(laelocation))
                    {
                        gamer.gameObject.SetActive(false);
                    }
                    else if (gamer.gameObject.name.Contains(laelocation))
                    {
                        gamer.gameObject.SetActive(true);
                    }
                }
            }
            else if (laelocation == "cam1b")
            {
                int randomthingy = betterrandom(1, 2);
                if (randomthingy == 1)
                {
                    prevlaelocation = laelocation;
                    laelocation = "cam7";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (randomthingy == 2)
                {
                    prevlaelocation = laelocation;
                    laelocation = "cam6";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    kitchenbanging.Play();
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if (laelocation == "cam7")
            {
                int randomthingy = betterrandom(1, 2);
                if (randomthingy == 1)
                {
                    prevlaelocation = laelocation;
                    laelocation = "cam4a";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (randomthingy == 2)
                {
                    prevlaelocation = laelocation;
                    laelocation = "cam6";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    kitchenbanging.Play();
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if (laelocation == "cam6")
            {
                int randomthingy = betterrandom(1, 2);
                if (randomthingy == 1)
                {
                    prevlaelocation = laelocation;
                    laelocation = "cam4a";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    kitchenbanging.Stop();
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (randomthingy == 2)
                {
                    prevlaelocation = laelocation;
                    laelocation = "cam7";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    kitchenbanging.Stop();
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if (laelocation == "cam4a")
            {
                int randomthingy = betterrandom(1, 2);
                if (randomthingy == 1)
                {
                    prevlaelocation = laelocation;
                    laelocation = "cam1b";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (randomthingy == 2)
                {
                    prevlaelocation = laelocation;
                    laelocation = "cam4b";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if (laelocation == "cam4b")
            {
                int randomthingy = betterrandom(1, 2);
                if (randomthingy == 1)
                {
                    prevlaelocation = laelocation;
                    laelocation = "atdoor";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    if (rightlight.lightstate == "on")
                    {
                        rightlight.turnlightoff();
                    }
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (randomthingy == 2)
                {
                    prevlaelocation = laelocation;
                    laelocation = "cam4a";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if (laelocation == "atdoor")
            {
                if (rightdoor.doorstate == "closed")
                {
                    prevlaelocation = laelocation;
                    laelocation = "cam4a";
                    if ((cameras.lastopenedcameraobject.name == laelocation || cameras.lastopenedcameraobject.name == prevlaelocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    if (rightlight.lightstate == "on")
                    {
                        rightlight.turnlightoff();
                    }
                    rightlight.haswindowscareplayed = false;
                    foreach (Transform gamer in laelocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(laelocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (rightdoor.doorstate == "open")
                {
                    laewantstoattack = true;
                    if (rightlight.lightstate == "on")
                    {
                        rightlight.turnlightoff();
                    }
                    rightdoor.locky();
                    rightlight.locky();
                }
            }
        }
    }
}
