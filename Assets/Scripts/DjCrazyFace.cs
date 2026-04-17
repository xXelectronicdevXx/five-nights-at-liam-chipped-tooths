using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DjCrazyFace : MonoBehaviour
{
    public int ailevel = 20;
    public GameObject dcflocations;
    public string dcflocation = "cam1a";
    public GameObject thingywingy;
    // for disabled when theres a jumpscare
    public buttons cameras;
    public LiamChippedTooth lct;
    public LiamAsianEye lae;
    public ColinSquishedFace csf;
    public doorbutton rightdoor;
    public mainnightstuff mns;
    public lightbutton rightlight;
    public lightbutton leftlight;
    public doorbutton leftdoor;
    public bool dcfwantstoattack = false;
    public GameObject jumpscarey;
    private string prevdcflocation = "";
    public GameObject thingies;
    // Start is called before the first frame update
    void Start()
    {
        if(mns.night == 1)
        {
            ailevel = 0;
        }
        else if (mns.night == 2)
        {
            ailevel = 3;
        }
        else if (mns.night == 3)
        {
            ailevel = 0;
        }
        else if (mns.night == 4)
        {
            ailevel = 2;
        }
        else if (mns.night == 5)
        {
            ailevel = 5;
        }
        else if (mns.night == 6)
        {
            ailevel = 10;
        }
        else if (mns.night == 7)
        {
            var data = customnightstuff.coolypoo2;

            ailevel = data.dcflevel;
        }
        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Movement()
    {
        while(true)
        {
            yield return new WaitForSeconds(4.97f);
            trytomove();
        }
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
        thingies.SetActive(false);
        cameras.enabled = false;
        lae.enabled = false;
        csf.enabled = false;
        lct.enabled = false;
        leftdoor.enabled = false;
        rightdoor.enabled = false;
        leftlight.enabled = false;
        rightlight.enabled = false;
        mns.enabled = false;
        jumpscarey.SetActive(true);
        foreach (Transform gamer in dcflocations.transform)
        {
            gamer.gameObject.SetActive(false);
        }
        StartCoroutine(lerpyboi(new Vector3(-0.00499999989f, 1f, -7.1420002f), 1.541f));
        Invoke("gameoverscreen", 1.541f);
    }

    public void trytomove()
    {
        int randomnum = betterrandom(1, 20);
        if(ailevel >= randomnum)
        {
            if(dcflocation == "cam1a")
            {
                int randomthingy = betterrandom(1, 2);
                if(randomthingy == 1)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam1b";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if(!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if(gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if(randomthingy == 2)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam5";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if(dcflocation == "cam1b")
            {
                int randomthingy = betterrandom(1, 2);
                if (randomthingy == 1)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam5";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (randomthingy == 2)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam2a";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if(dcflocation == "cam5")
            {
                int randomthingy = betterrandom(1, 2);
                if (randomthingy == 1)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam1b";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (randomthingy == 2)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam2a";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if(dcflocation == "cam2a")
            {
                int randomthingy = betterrandom(1, 2);
                if (randomthingy == 1)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam3";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (randomthingy == 2)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam2b";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if(dcflocation == "cam2b")
            {
                int randomthingy = betterrandom(1, 2);
                if (randomthingy == 1)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam3";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (randomthingy == 2)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "atdoor";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    if (leftlight.lightstate == "on")
                    {
                        leftlight.turnlightoff();
                    }
                    thingywingy.SetActive(true);
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if(dcflocation == "cam3")
            {
                int randomthingy = betterrandom(1, 2);
                if (randomthingy == 1)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam2a";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (randomthingy == 2)
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "atdoor";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    if (leftlight.lightstate == "on")
                    {
                        leftlight.turnlightoff();
                    }
                    thingywingy.SetActive(true);
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if(dcflocation == "atdoor")
            {
                if(leftdoor.doorstate == "closed")
                {
                    prevdcflocation = dcflocation;
                    dcflocation = "cam1b";
                    if ((cameras.lastopenedcameraobject.name == dcflocation || cameras.lastopenedcameraobject.name == prevdcflocation) && cameras.camsopen == true)
                    {
                        cameras.camscookedtime = 5f;
                    }
                    if (leftlight.lightstate == "on")
                    {
                        leftlight.turnlightoff();
                    }
                    leftlight.haswindowscareplayed = false;
                    thingywingy.SetActive(false);
                    foreach (Transform gamer in dcflocations.transform)
                    {
                        if (!gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(false);
                        }
                        else if (gamer.gameObject.name.Contains(dcflocation))
                        {
                            gamer.gameObject.SetActive(true);
                        }
                    }
                }
                else if (leftdoor.doorstate == "open")
                {
                    dcfwantstoattack = true;
                    if (leftlight.lightstate == "on")
                    {
                        leftlight.turnlightoff();
                    }
                    leftdoor.locky();
                    leftlight.locky();
                }
            }
        }
    }
}
