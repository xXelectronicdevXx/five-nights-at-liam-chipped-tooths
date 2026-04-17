using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class blackdisappear : MonoBehaviour
{
    public Image img;
    public AudioSource doodoo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cblackdisappear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator cblackdisappear()
    {
        doodoo.Play();
        yield return new WaitForSeconds(3f);
        doodoo.Play();
        img.enabled = false;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("nightintro");
    }
}
