using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldenlctjumpscare : MonoBehaviour
{
    public AudioSource jumpscare;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ahhhhh());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Ahhhhh()
    {
        jumpscare.Play();
        yield return new WaitForSeconds(1.019f);
        Application.Quit();
    }
}
