using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class customnightstuff : MonoBehaviour
{
    public static customnightstuff coolypoo2;
    public int lctlevel = 0;
    public int dcflevel = 0;
    public int laelevel = 0;
    public int csflevel = 0;
    public TextMeshProUGUI lctleveltext;
    public TextMeshProUGUI dcfleveltext;
    public TextMeshProUGUI laeleveltext;
    public TextMeshProUGUI csfleveltext;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (coolypoo2 == null)
        {
            coolypoo2 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu")
        {
            Destroy(gameObject);
            coolypoo2 = null;
        }
        else if (scene.name == "customnightmenu")
        {
            Button readyButton = GameObject.Find("start").GetComponent<Button>();
            readyButton.onClick.RemoveAllListeners();
            readyButton.onClick.AddListener(readybuttonpressed);
            Button lctincreasebutton = GameObject.Find("lctincrease").GetComponent<Button>();
            lctincreasebutton.onClick.RemoveAllListeners();
            lctincreasebutton.onClick.AddListener(lctincreasebuttonpressed);
            Button lctdecreasebutton = GameObject.Find("lctdecrease").GetComponent<Button>();
            lctdecreasebutton.onClick.RemoveAllListeners();
            lctdecreasebutton.onClick.AddListener(lctdecreasebuttonpressed);
            Button dcfincreasebutton = GameObject.Find("dcfincrease").GetComponent<Button>();
            dcfincreasebutton.onClick.RemoveAllListeners();
            dcfincreasebutton.onClick.AddListener(dcfincreasebuttonpressed);
            Button dcfdecreasebutton = GameObject.Find("dcfdecrease").GetComponent<Button>();
            dcfdecreasebutton.onClick.RemoveAllListeners();
            dcfdecreasebutton.onClick.AddListener(dcfdecreasebuttonpressed);
            Button laeincreasebutton = GameObject.Find("laeincrease").GetComponent<Button>();
            laeincreasebutton.onClick.RemoveAllListeners();
            laeincreasebutton.onClick.AddListener(laeincreasebuttonpressed);
            Button laedecreasebutton = GameObject.Find("laedecrease").GetComponent<Button>();
            laedecreasebutton.onClick.RemoveAllListeners();
            laedecreasebutton.onClick.AddListener(laedecreasebuttonpressed);
            Button csfincreasebutton = GameObject.Find("csfincrease").GetComponent<Button>();
            csfincreasebutton.onClick.RemoveAllListeners();
            csfincreasebutton.onClick.AddListener(csfincreasebuttonpressed);
            Button csfdecreasebutton = GameObject.Find("csfdecrease").GetComponent<Button>();
            csfdecreasebutton.onClick.RemoveAllListeners();
            csfdecreasebutton.onClick.AddListener(csfdecreasebuttonpressed);
            lctleveltext = GameObject.Find("lctailevel").GetComponent<TextMeshProUGUI>();
            dcfleveltext = GameObject.Find("dcfailevel").GetComponent<TextMeshProUGUI>();
            laeleveltext = GameObject.Find("laeailevel").GetComponent<TextMeshProUGUI>();
            csfleveltext = GameObject.Find("csfailevel").GetComponent<TextMeshProUGUI>();
            lctleveltext.text = lctlevel.ToString();
            dcfleveltext.text = dcflevel.ToString();
            laeleveltext.text = laelevel.ToString();
            csfleveltext.text = csflevel.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lctincreasebuttonpressed()
    {
        if(lctlevel != 20)
        {
            lctlevel++;
            lctleveltext.text = lctlevel.ToString();
        }
        else if(lctlevel == 20)
        {
            lctlevel = 0;
            lctleveltext.text = lctlevel.ToString();
        }
    }

    public void lctdecreasebuttonpressed()
    {
        if (lctlevel != 0)
        {
            lctlevel--;
            lctleveltext.text = lctlevel.ToString();
        }
        else if (lctlevel == 0)
        {
            lctlevel = 20;
            lctleveltext.text = lctlevel.ToString();
        }
    }

    public void dcfincreasebuttonpressed()
    {
        if (dcflevel != 20)
        {
            dcflevel++;
            dcfleveltext.text = dcflevel.ToString();
        }
        else if (dcflevel == 20)
        {
            dcflevel = 0;
            dcfleveltext.text = dcflevel.ToString();
        }
    }

    public void dcfdecreasebuttonpressed()
    {
        if (dcflevel != 0)
        {
            dcflevel--;
            dcfleveltext.text = dcflevel.ToString();
        }
        else if (dcflevel == 0)
        {
            dcflevel = 20;
            dcfleveltext.text = dcflevel.ToString();
        }
    }

    public void laeincreasebuttonpressed()
    {
        if (laelevel != 20)
        {
            laelevel++;
            laeleveltext.text = laelevel.ToString();
        }
        else if (laelevel == 20)
        {
            laelevel = 0;
            laeleveltext.text = laelevel.ToString();
        }
    }

    public void laedecreasebuttonpressed()
    {
        if (laelevel != 0)
        {
            laelevel--;
            laeleveltext.text = laelevel.ToString();
        }
        else if (laelevel == 0)
        {
            laelevel = 20;
            laeleveltext.text = laelevel.ToString();
        }
    }

    public void csfincreasebuttonpressed()
    {
        if (csflevel != 20)
        {
            csflevel++;
            csfleveltext.text = csflevel.ToString();
        }
        else if (csflevel == 20)
        {
            csflevel = 0;
            csfleveltext.text = csflevel.ToString();
        }
    }

    public void csfdecreasebuttonpressed()
    {
        if (csflevel != 0)
        {
            csflevel--;
            csfleveltext.text = csflevel.ToString();
        }
        else if (csflevel == 0)
        {
            csflevel = 20;
            csfleveltext.text = csflevel.ToString();
        }
    }

    public void readybuttonpressed()
    {
        if(!(lctlevel == 1 && dcflevel == 9 && laelevel == 8 && csflevel == 7))
        {
            globalbars.coolypoo.nighttoplay = 7;
            SceneManager.LoadScene("nightintro");
        }
        else
        {
            SceneManager.LoadScene("golden lct jumpscare");
        }
    }
}
