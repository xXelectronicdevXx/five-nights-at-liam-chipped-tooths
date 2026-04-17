using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColinSquishedFace : MonoBehaviour
{
    public int ailevel = 20;
    public int phase = 1;
    public GameObject curtainsphase1;
    public GameObject curtainsphase2;
    public GameObject curtainsphase3;
    public GameObject curtainsphase4;
    public GameObject csfphase2;
    public GameObject csfphase3;
    public GameObject csfrundownhall;
    public bool attacking = false;
    public bool csfcooldown = false;
    private int times_hitdoor;
    public AudioSource clang;
    // for jumpscare
    public buttons cameras;
    public DjCrazyFace dcf;
    public LiamAsianEye lae;
    public LiamChippedTooth lct;
    public doorbutton leftdoor;
    public doorbutton rightdoor;
    public lightbutton leftlight;
    public lightbutton rightlight;
    public mainnightstuff mns;
    public GameObject jumpscarey;
    public bool wantstobeattacking = false;
    public GameObject thingies;
    public float stuntime = 0f;
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
            ailevel = 2;
        }
        else if (mns.night == 4)
        {
            ailevel = 6;
        }
        else if (mns.night == 5)
        {
            ailevel = 5;
        }
        else if (mns.night == 6)
        {
            ailevel = 6;
        }
        else if (mns.night == 7)
        {
            var data = customnightstuff.coolypoo2;

            ailevel = data.csflevel;
        }
        StartCoroutine(Movement());
    }

    int betterrandom(int min, int max)
    {
        return Random.Range(min, max + 1);
    }

    IEnumerator Movement()
    {
        while(true)
        {
            yield return new WaitForSeconds(5.01f);
            trytomove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stuntime > 0)
        {
            stuntime -= Time.deltaTime;
        }
        if (cameras.camsopen == true)
        {
            stuntime = Random.Range(0.83f, 17.48f);
        }
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
        if (cameras.camsopen == true)
        {
            cameras.forcecamsdown();
        }
        thingies.SetActive(false);
        cameras.enabled = false;
        dcf.enabled = false;
        lae.enabled = false;
        lct.enabled = false;
        leftdoor.enabled = false;
        rightdoor.enabled = false;
        leftlight.enabled = false;
        rightlight.enabled = false;
        mns.enabled = false;
        jumpscarey.SetActive(true);
        StartCoroutine(lerpyboi(new Vector3(-1.08000004f, 0.744599998f, -5.60699987f), 0.25f));
        Invoke("gameoverscreen", 0.993f);
    }

    public IEnumerator run()
    {
        wantstobeattacking = false;
        csfrundownhall.SetActive(true);
        Vector3 startpos = csfrundownhall.transform.position;
        Vector3 targetpos = new Vector3(140.268005f, 1.16999996f, -23.8799992f);
        float elapsedtime = 0f;
        while (elapsedtime < 1.5f)
        {
            float t = elapsedtime / 1.5f;
            t = Mathf.Clamp01(t);
            csfrundownhall.transform.position = Vector3.Lerp(startpos, targetpos, t);
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        csfrundownhall.transform.position = targetpos;
        csfrundownhall.SetActive(false);
        attacky();
        csfrundownhall.transform.position = startpos;
    }

    public void trytomove()
    {
        int randomnum = betterrandom(1, 20);
        if (ailevel >= randomnum && attacking == false && phase < 4 && stuntime <= 0f)
        {
            phase += 1;
            if(phase == 2)
            {
                curtainsphase1.SetActive(false);
                curtainsphase2.SetActive(true);
                csfphase2.SetActive(true);
            }
            else if (phase == 3)
            {
                curtainsphase2.SetActive(false);
                curtainsphase3.SetActive(true);
                csfphase2.SetActive(false);
                csfphase3.SetActive(true);
            }
            else if (phase == 4)
            {
                curtainsphase3.SetActive(false);
                curtainsphase4.SetActive(true);
                csfphase3.SetActive(false);
                wantstobeattacking = true;
            }
        }
    }
    public void attacky()
    {
        if (leftdoor.doorstate == "closed" || leftdoor.doorstate == "closing")
        {
            int randomnum = betterrandom(1, 2);
            wantstobeattacking = false;
            attacking = false;
            clang.Play();
            mns.power -= (10 + (50 * times_hitdoor));
            times_hitdoor += 1;
            cameras.csfstun = 0f;
            if (randomnum == 1)
            {
                phase = 1;
                curtainsphase4.SetActive(false);
                curtainsphase1.SetActive(true);
            }
            else if (randomnum == 2)
            {
                phase = 2;
                curtainsphase4.SetActive(false);
                curtainsphase2.SetActive(true);
                csfphase2.SetActive(true);
            }
        }
        else if (leftdoor.doorstate == "open" || leftdoor.doorstate == "opening")
        {
            if(cameras.camsopen == true)
            {
                cameras.forcecamsdown();
            }
            wantstobeattacking = false;
            attacking = false;
            jumpscare();
        }
    }
}
