using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class doorbutton : MonoBehaviour
{
    public string doorstate = "open";
    public GameObject door;
    public Material dooropenmat;
    public mainnightstuff mns;
    public Material doorclosedmat;
    private Renderer objectRenderer;
    private Vector3 startposy;
    private Vector3 endpos;
    public AudioSource doorsound;
    public AudioClip lockedsound;
    public bool locked = false;
    private bool debounce = false;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        startposy = door.transform.position;
        endpos = door.transform.position - new Vector3(0f, 2.441f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator lerpyboi(Vector3 targetpos, float duration)
    {
        Vector3 startpos = door.transform.position;
        float elapsedtime = 0f;
        debounce = true;
        while (elapsedtime < duration)
        {
            float t = elapsedtime / duration;
            t = Mathf.Clamp01(t);
            door.transform.position = Vector3.Lerp(startpos, targetpos, t);
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        door.transform.position = targetpos;
        debounce = false;
        if (door.transform.position == endpos)
        {
            doorstate = "closed";
        }
        else if (door.transform.position == startposy)
        {
            doorstate = "open";
        }
        if(mns.powerdown == true)
        {
            this.enabled = false;
        }
    }

    public void locky()
    {
        doorsound.clip = lockedsound;
        locked = true;
    }

    public void forcedooropen()
    {
        doorsound.Play();
        doorstate = "opening";
        objectRenderer.material = dooropenmat;
        StartCoroutine(lerpyboi(startposy, 0.25f));
    }


    private void OnMouseDown()
    {
        if(mns.powerdown == false)
        {
            if (locked == false)
            {
                if (doorstate == "open")
                {
                    if (debounce == false)
                    {
                        doorsound.Play();
                        doorstate = "closing";
                        objectRenderer.material = doorclosedmat;
                        StartCoroutine(lerpyboi(endpos, 0.25f));
                    }
                }
                else if (doorstate == "closed")
                {
                    if (debounce == false)
                    {
                        doorsound.Play();
                        doorstate = "opening";
                        objectRenderer.material = dooropenmat;
                        StartCoroutine(lerpyboi(startposy, 0.25f));
                    }
                }
            }
            else if (locked == true)
            {
                doorsound.Play();
            }
        }
    }
}
