using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttons : MonoBehaviour
{
    public bool camsopen = false;
    public TextMeshProUGUI opencamsbuttontext;
    public TextMeshProUGUI viewingcameratext;
    public GameObject camsthings;
    public GameObject maincam;
    public GameObject cam1a;
    public GameObject cam1b;
    public GameObject cam1c;
    public GameObject cam2a;
    public GameObject cam2b;
    public GameObject cam3;
    public GameObject cam4a;
    public GameObject cam4b;
    public GameObject cam5;
    public GameObject cam6;
    public GameObject cam7;
    public GameObject allcameras;
    public GameObject lastopenedcameraobject;
    public ColinSquishedFace csf;
    public LiamChippedTooth lct;
    public LiamAsianEye lae;
    public DjCrazyFace dcf;
    public lightbutton leftlight;
    public lightbutton rightlight;
    public doorbutton rightdoor;
    public AudioSource cameraviewsound;
    public AudioSource cameraswitchsound;
    public AudioSource camscookednoise;
    public float timeincams = 0f;
    public float camscookedtime = 0f;
    public bool camscooked = false;
    public float timenotlookedathall = 0f;
    public float csfstun = 0f;
    // Start is called before the first frame update
    void Start()
    {
        lastopenedcameraobject = cam1a;
        StartCoroutine(camscookedness());
    }

    // Update is called once per frame
    void Update()
    {
        if(camsopen == true)
        {
            timeincams += Time.deltaTime;
            if(timeincams >= 30f && lae.laewantstoattack == true)
            {
                forcecamsdown();
            }
            else if (timeincams >= 30f && dcf.dcfwantstoattack == true)
            {
                forcecamsdown();
            }
        }
        else
        {
            timeincams = 0f;
        }
        if(camscookedtime > 0f)
        {
            camscookedtime -= Time.deltaTime;
        }
        else
        {
            camscookedtime = 0f;
        }
        if(csf.wantstobeattacking == true && !(lastopenedcameraobject == cam2a && camsopen == true))
        {
            timenotlookedathall += Time.deltaTime;
            if(timenotlookedathall >= 25f)
            {
                csf.attacky();
                timenotlookedathall = 0f;
            }
        }
        if(csfstun > 0f)
        {
            csfstun -= Time.deltaTime;
        }
        else
        {
            csfstun = 0f;
        }
    }

    IEnumerator camscookedness()
    {
        while(true)
        {
            yield return new WaitUntil(() => camscookedtime > 0f);
            cameraswitchsound.Play();
            camscookednoise.Play();
            foreach (Transform kid in allcameras.transform)
            {
                if (kid.gameObject.TryGetComponent<Camera>(out Camera cool))
                {
                    cool.cullingMask = 0;
                }
            }
            yield return new WaitUntil(() => camscookedtime <= 0f);
            camscookednoise.Stop();
            foreach (Transform kid in allcameras.transform)
            {
                if (kid.gameObject.TryGetComponent<Camera>(out Camera cool))
                {
                    cool.cullingMask = int.MaxValue;
                }
            }
        }
    }

    public void forcecamsdown()
    {
        camsopen = false;
        if (lae.laewantstoattack == true)
        {
            lae.jumpscare();
        }
        if (dcf.dcfwantstoattack == true)
        {
            dcf.jumpscare();
        }
        cameraviewsound.Play();
        csfstun = Random.Range(0.83f, 17.48f);
        opencamsbuttontext.text = "View Cameras";
        lastopenedcameraobject.SetActive(false);
        camsthings.SetActive(false);
        allcameras.SetActive(false);
        maincam.SetActive(true);
    }

    public void ViewCamsButtonPressed()
    {
        if (camsopen == false)
        {
            camsopen = true;
            camscookednoise.volume = 1f;
            csfstun = 0f;
            cameraviewsound.Play();
            leftlight.turnlightoff();
            rightlight.turnlightoff();
            opencamsbuttontext.text = "Exit Cameras";
            camsthings.SetActive(true);
            if (lastopenedcameraobject != cam6)
            {
                maincam.SetActive(false);
            }
            if (lastopenedcameraobject != cam4b && lct.isinattackmode == true && rightdoor.doorstate == "open" && lct.isinsuperattackmode == false)
            {
                lct.goinsuperattackmode();
            }
            else if (lastopenedcameraobject != cam4b && lct.isinattackmode == true && rightdoor.doorstate == "closed" && lct.isinsuperattackmode == false)
            {
                if(lastopenedcameraobject != cam4a)
                {
                    lct.gobackto4a();
                }
            }
            if (lastopenedcameraobject == cam2a)
            {
                if (csf.phase == 4 && csf.attacking == false)
                {
                    csf.attacking = true;
                    StartCoroutine(csf.run());
                }
            }
            allcameras.SetActive(true);
            lastopenedcameraobject.SetActive(true);
        }
        else if (camsopen == true)
        {
            camsopen = false;
            camscookednoise.volume = 0f;
            if (lae.laewantstoattack == true)
            {
                lae.jumpscare();
            }
            if (dcf.dcfwantstoattack == true)
            {
                dcf.jumpscare();
            }
            cameraviewsound.Play();
            opencamsbuttontext.text = "View Cameras";
            lastopenedcameraobject.SetActive(false);
            camsthings.SetActive(false);
            allcameras.SetActive(false);
            maincam.SetActive(true);
        }
    }

    public void camerabuttonpress(string cameraname)
    {
        cameraswitchsound.Play();

        foreach (Transform kid in camsthings.transform)
        {
            if (kid.gameObject.name != cameraname && kid.gameObject.TryGetComponent<Button>(out Button cool))
            {
                cool.interactable = true;
            }
            else if (kid.gameObject.name == cameraname && kid.gameObject.TryGetComponent<Button>(out Button cool2))
            {
                cool2.interactable = false;
            }
        }
        if (cameraname != "cam4b" && lct.isinattackmode == true && lct.isinsuperattackmode == false && rightdoor.doorstate == "open")
        {
            lct.goinsuperattackmode();
        }
        else if (cameraname != "cam4b" && lct.isinattackmode == true && lct.isinsuperattackmode == false && rightdoor.doorstate == "closed")
        {
            lct.gobackto4a();
        }
        if (cameraname == "cam1a")
        {
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(false);
            cam1a.SetActive(true);
            lastopenedcameraobject = cam1a;
            viewingcameratext.text = "Show Stage";
        }
        else if (cameraname == "cam1b")
        {
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(false);
            cam1b.SetActive(true);
            lastopenedcameraobject = cam1b;
            viewingcameratext.text = "Dining Area";
        }
        else if (cameraname == "cam1c")
        {
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(false);
            cam1c.SetActive(true);
            lastopenedcameraobject = cam1c;
            viewingcameratext.text = "Pirate Cove";
        }
        else if (cameraname == "cam2a")
        {
            if (csf.phase == 4 && csf.attacking == false)
            {
                csf.attacking = true;
                StartCoroutine(csf.run());
            }
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(false);
            cam2a.SetActive(true);
            lastopenedcameraobject = cam2a;
            viewingcameratext.text = "West Hall";
        }
        else if (cameraname == "cam2b")
        {
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(false);
            cam2b.SetActive(true);
            lastopenedcameraobject = cam2b;
            viewingcameratext.text = "W. Hall Corner";
        }
        else if (cameraname == "cam3")
        {
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(false);
            cam3.SetActive(true);
            lastopenedcameraobject = cam3;
            viewingcameratext.text = "Supply Closet";
        }
        else if (cameraname == "cam4a")
        {
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(false);
            cam4a.SetActive(true);
            lastopenedcameraobject = cam4a;
            viewingcameratext.text = "East Hall";
        }
        else if (cameraname == "cam4b")
        {
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(false);
            cam4b.SetActive(true);
            lastopenedcameraobject = cam4b;
            viewingcameratext.text = "E. Hall Corner";
        }
        else if (cameraname == "cam5")
        {
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(false);
            cam5.SetActive(true);
            lastopenedcameraobject = cam5;
            viewingcameratext.text = "Backstage";
        }
        else if (cameraname == "cam6")
        {
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(true);
            cam6.SetActive(true);
            lastopenedcameraobject = cam6;
            viewingcameratext.text = "Kitchen";
        }
        else if (cameraname == "cam7")
        {
            lastopenedcameraobject.SetActive(false);
            maincam.SetActive(false);
            cam7.SetActive(true);
            lastopenedcameraobject = cam7;
            viewingcameratext.text = "Restrooms";
        }
    }
}
