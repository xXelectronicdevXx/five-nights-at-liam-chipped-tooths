using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(demoend());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator demoend()
    {
        yield return new WaitForSeconds(10f);
        Application.Quit();
    }
}
