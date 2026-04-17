using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honker : MonoBehaviour
{

    public AudioSource honk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        honk.Play();
    }
}
