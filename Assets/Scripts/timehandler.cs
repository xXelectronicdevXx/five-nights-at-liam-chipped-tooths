using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timehandler : MonoBehaviour
{
    public TextMeshProUGUI time;
    public DjCrazyFace dcf;
    public LiamAsianEye lae;
    public ColinSquishedFace csf;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Clock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Clock()
    {
        yield return new WaitForSeconds(90f);
        time.text = "1 am";
        yield return new WaitForSeconds(89f);
        time.text = "2 am";
        dcf.ailevel++;
        yield return new WaitForSeconds(89f);
        time.text = "3 am";
        dcf.ailevel++;
        lae.ailevel++;
        csf.ailevel++;
        yield return new WaitForSeconds(89f);
        time.text = "4 am";
        dcf.ailevel++;
        lae.ailevel++;
        csf.ailevel++;
        yield return new WaitForSeconds(89f);
        time.text = "5 am";
        yield return new WaitForSeconds(89f);
        SceneManager.LoadScene("6am");
    }
}
