using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class callhandler : MonoBehaviour
{
    public mainnightstuff mns;
    public AudioSource source;
    public AudioClip night1call;
    public AudioClip night2call;
    public AudioClip night3call;
    public AudioClip night4call;
    public GameObject mutecallbutton;
    // Start is called before the first frame update
    void Start()
    {
        if(mns.night == 1)
        {
            source.clip = night1call;
        }
        else if (mns.night == 2)
        {
            source.clip = night2call;
        }
        else if (mns.night == 3)
        {
            source.clip = night3call;
        }
        else if (mns.night == 4)
        {
            source.clip = night4call;
        }
        else if(mns.night > 4)
        {
            Destroy(source);
        }
        if(mns.night < 5)
        {
            StartCoroutine(call());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator call()
    {
        yield return new WaitForSeconds(3f);
        mutecallbutton.SetActive(true);
        source.Play();
        yield return new WaitUntil(() => source.isPlaying == false);
        mutecallbutton.SetActive(false);
    }

    public void mutecallbuttonpressed()
    {
        source.Stop();
        StopAllCoroutines();
        mutecallbutton.SetActive(false);
    }
}
