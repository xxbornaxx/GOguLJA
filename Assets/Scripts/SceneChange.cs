using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange: MonoBehaviour
{
    public int mp;
    public bool drugi = false;

    public void Update()
    {
        mp = MovePanels.instance.panel;
        if (SwipeDetection.instance.output=="tap")
        {
            if (drugi! == false)
            {
                SceneManager.LoadScene(1 + mp);
            }
            if (drugi == true)
            {
                SceneManager.LoadScene(1 + mp + 10);
            }
        }
    }
    public void ChangeBoolTrue()
    {
        drugi = true;
    }
    public void ChangeBoolFalse()
    {
        drugi = false;
    }
}
