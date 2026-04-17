using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eastereggs : MonoBehaviour
{
    public ColinSquishedFace csf;
    public AudioSource diddlydum;
    public AudioSource fire;
    public mainnightstuff mns;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(foxysong());
        StartCoroutine(corysong());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int betterrandom(int min, int max)
    {
        return Random.Range(min, max + 1);
    }

    IEnumerator foxysong()
    {
        while(true)
        {
            yield return new WaitForSeconds(4f);
            int randomnum = betterrandom(1, 30);
            if (randomnum == 1 && csf.phase == 1 && diddlydum.isPlaying == false && mns.power > 0)
            {
                diddlydum.Play();
            }
        }
    }

    IEnumerator corysong()
    {
        while(true)
        {
            yield return new WaitForSeconds(5f);
            int randomnum = betterrandom(1, 30);
            if (randomnum == 1 && fire.isPlaying == false && mns.power > 0)
            {
                fire.Play();
            }
        }
    }
}
