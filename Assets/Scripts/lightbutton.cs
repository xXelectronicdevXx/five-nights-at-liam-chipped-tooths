using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class lightbutton : MonoBehaviour
{
    public string lightstate = "off";
    public GameObject lighty;
    private Renderer objectRenderer;
    public Material lightonmat;
    public Material lightoffmat;
    public lightbutton otherlightbutton;
    public AudioSource lightonsound;
    public AudioSource windowscare;
    public GameObject animatronicatdoorobject;
    public mainnightstuff mns;
    public AudioClip lockedsound;
    public bool locked = false;
    public bool haswindowscareplayed = false;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void locky()
    {
        lightonsound.clip = lockedsound;
        lightonsound.loop = false;
        locked = true;
    }

    public void turnlightoff()
    {
        lightstate = "off";
        lightonsound.Stop();
        lighty.SetActive(false);
        objectRenderer.material = lightoffmat;
        if (mns.powerdown == true)
        {
            this.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if(mns.powerdown == false)
        {
            if (locked == false)
            {
                if (lightstate == "off")
                {
                    lightstate = "on";
                    lightonsound.Play();
                    if (animatronicatdoorobject.activeInHierarchy == true && haswindowscareplayed == false)
                    {
                        windowscare.Play();
                        haswindowscareplayed = true;
                    }
                    otherlightbutton.turnlightoff();
                    lighty.SetActive(true);
                    objectRenderer.material = lightonmat;
                }
                else if (lightstate == "on")
                {
                    lightstate = "off";
                    lightonsound.Stop();
                    lighty.SetActive(false);
                    objectRenderer.material = lightoffmat;
                }
            }
            else if (locked == true)
            {
                lightonsound.Play();
            }
        }
    }
}
