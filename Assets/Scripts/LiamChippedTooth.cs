using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiamChippedTooth : MonoBehaviour
{
    public int ailevel = 20;
    public string lctlocation = "cam1a";
    private string prevlctlocation = "";
    public bool thingygoing = false;
    public GameObject lctlocations;
    public bool isinattackmode = false;
    public bool isinsuperattackmode = false;
    public GameObject cam4b;
    public AudioSource musicbox;
    public GameObject cam6;
    //ball
    public buttons cameras;
    public DjCrazyFace dcf;
    public LiamAsianEye lae;
    public ColinSquishedFace csf;
    public doorbutton rightdoor;
    public mainnightstuff mns;
    public lightbutton rightlight;
    public lightbutton leftlight;
    public doorbutton leftdoor;
    public bool dcfwantstoattack = false;
    public GameObject jumpscarey;
    public AudioSource goofyahhlaugh;
    public GameObject thingies;

    private int progression = 0;
    private float movetimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (mns.night == 1)
        {
            ailevel = 0;
        }
        else if (mns.night == 2)
        {
            ailevel = 0;
        }
        else if (mns.night == 3)
        {
            ailevel = 1;
        }
        else if (mns.night == 4)
        {
            int rand = betterrandom(1, 2);
            if(rand == 1)
            {
                ailevel = 1;
            }
            else if (rand == 2)
            {
                ailevel = 2;
            }
        }
        else if (mns.night == 5)
        {
            ailevel = 3;
        }
        else if (mns.night == 6)
        {
            ailevel = 4;
        }
        else if (mns.night == 7)
        {
            var data = customnightstuff.coolypoo2;

            ailevel = data.lctlevel;
        }
        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    {
        if (cameras.lastopenedcameraobject == cam6 && cameras.camsopen == true)
        {
            musicbox.volume = 1f;
        }
        else
        {
            musicbox.volume = 0f;
        }
        if(progression == 2)
        {
            if(lctlocation != "cam4b")
            {
                move();
            }
            else
            {
                if(cameras.camsopen == true)
                {
                    if(cameras.lastopenedcameraobject.name != "cam4b")
                    {
                        move();
                    }
                }
            }
        }
        else if(progression == 1)
        {
            movetimer += Time.deltaTime;

            if(ailevel < 10)
            {
                if (movetimer >= (1f / 60f * (1000 - (100 * ailevel))))
                {
                    if (cameras.camsopen == false)
                    {
                        movetimer = 0f;
                        progression = 2;
                    }
                }
            }
            else
            {
                if (cameras.camsopen == false)
                {
                    movetimer = 0f;
                    progression = 2;
                }
            }
        }

        if(cameras.camsopen == true)
        {
            if(cameras.lastopenedcameraobject.name == lctlocation)
            {
                movetimer = 0f;
            }
        }
    }

    IEnumerator Movement()
    {
        while(true)
        {
            yield return new WaitForSeconds(3.02f);
            if (betterrandom(1, 20) <= ailevel)
            {
                if (cameras.camsopen == false)
                {
                    progression = 1;
                }
            }
        }
    }

    int betterrandom(int min, int max)
    {
        return Random.Range(min, max + 1);
    }



    public void move()
    {
        progression = 0;
        if(lctlocation == "cam1a" && dcf.dcflocation != "cam1a" && lae.laelocation != "cam1a")
        {
            prevlctlocation = lctlocation;
            lctlocation = "cam1b";
            goofyahhlaugh.Play();
            foreach (Transform gamer in lctlocations.transform)
            {
                if (!gamer.gameObject.name.Contains(lctlocation))
                {
                    gamer.gameObject.SetActive(false);
                }
                else if (gamer.gameObject.name.Contains(lctlocation))
                {
                    gamer.gameObject.SetActive(true);
                }
            }
        }
        else if (lctlocation == "cam1b")
        {
            prevlctlocation = lctlocation;
            lctlocation = "cam7";
            goofyahhlaugh.Play();
            foreach (Transform gamer in lctlocations.transform)
            {
                if (!gamer.gameObject.name.Contains(lctlocation))
                {
                    gamer.gameObject.SetActive(false);
                }
                else if (gamer.gameObject.name.Contains(lctlocation))
                {
                    gamer.gameObject.SetActive(true);
                }
            }
        }
        else if (lctlocation == "cam7")
        {
            prevlctlocation = lctlocation;
            lctlocation = "cam6";
            goofyahhlaugh.Play();
            musicbox.Play();
            foreach (Transform gamer in lctlocations.transform)
            {
                if (!gamer.gameObject.name.Contains(lctlocation))
                {
                    gamer.gameObject.SetActive(false);
                }
                else if (gamer.gameObject.name.Contains(lctlocation))
                {
                    gamer.gameObject.SetActive(true);
                }
            }
        }
        else if (lctlocation == "cam6")
        {
            prevlctlocation = lctlocation;
            lctlocation = "cam4a";
            goofyahhlaugh.Play();
            musicbox.Stop();
            foreach (Transform gamer in lctlocations.transform)
            {
                if (!gamer.gameObject.name.Contains(lctlocation))
                {
                    gamer.gameObject.SetActive(false);
                }
                else if (gamer.gameObject.name.Contains(lctlocation))
                {
                    gamer.gameObject.SetActive(true);
                }
            }
        }
        else if (lctlocation == "cam4a")
        {
            prevlctlocation = lctlocation;
            lctlocation = "cam4b";
            goofyahhlaugh.Play();
            foreach (Transform gamer in lctlocations.transform)
            {
                if (!gamer.gameObject.name.Contains(lctlocation))
                {
                    gamer.gameObject.SetActive(false);
                }
                else if (gamer.gameObject.name.Contains(lctlocation))
                {
                    gamer.gameObject.SetActive(true);
                }
            }
        }
        else if (lctlocation == "cam4b")
        {
            isinattackmode = true;
            StopCoroutine(Movement());
        }
    }

    public void goinsuperattackmode()
    {
        isinsuperattackmode = true;
        foreach (Transform gamer in lctlocations.transform)
        {
            gamer.gameObject.SetActive(false);
        }
        StartCoroutine(Finaljumpscarethingy());
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
        dcf.enabled = false;
        leftdoor.enabled = false;
        rightdoor.enabled = false;
        leftlight.enabled = false;
        rightlight.enabled = false;
        mns.enabled = false;
        jumpscarey.SetActive(true);
        foreach (Transform gamer in lctlocations.transform)
        {
            gamer.gameObject.SetActive(false);
        }
        StartCoroutine(lerpyboi(new Vector3(-0.00499999989f, 1f, -7.1420002f), 0.601f));
        Invoke("gameoverscreen", 0.601f);
    }

    IEnumerator Finaljumpscarethingy()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            if(cameras.camsopen == false)
            {
                int randomnum = betterrandom(1, 4);
                if(randomnum == 1)
                {
                    jumpscare();
                    StopCoroutine(Finaljumpscarethingy());
                }
            }
        }
    }

    public void gobackto4a()
    {
        lctlocation = "cam4a";
        goofyahhlaugh.Play();
        StopAllCoroutines();
        StartCoroutine(Movement());
        isinattackmode = false;
        isinsuperattackmode = false;
        foreach (Transform gamer in lctlocations.transform)
        {
            if (!gamer.gameObject.name.Contains(lctlocation))
            {
                gamer.gameObject.SetActive(false);
            }
            else if (gamer.gameObject.name.Contains(lctlocation))
            {
                gamer.gameObject.SetActive(true);
            }
        }
    }
}
