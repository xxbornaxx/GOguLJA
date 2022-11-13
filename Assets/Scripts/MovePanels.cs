using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePanels : MonoBehaviour
{
    public static MovePanels instance;

    public GameObject DotsGJ;
    public GameObject[] panels;
    public Sprite[] dots;
    public int panel = 0;
    public int maxPanela;
    private void Start()
    {
        instance = this;
        maxPanela = panels.Length-1;
    }
    private void Update()
    {
        Panel();
        Dots();
    }

    void Panel()
    {
        if (panel<0)
        {
            panel = 0;
        }
        if (panel >maxPanela)
        {
            panel = maxPanela;
        }
        if (panel > 0 && panel < maxPanela)
        {
            if (SwipeDetection.instance.output == "left")
            {
                panels[panel].SetActive(false);
                panel++;
                panels[panel].SetActive(true);
                SwipeDetection.instance.output = "";
            }
            if (SwipeDetection.instance.output == "right")
            {
                panels[panel].SetActive(false);
                panel--;
                panels[panel].SetActive(true);
                SwipeDetection.instance.output = "";
            }
        }

        else if (panel == 0)
        {
            if (SwipeDetection.instance.output == "left")
            {
                panels[panel].SetActive(false);
                panel++;
                panels[panel].SetActive(true);
                SwipeDetection.instance.output = "";
            }
        }

        else if (panel == maxPanela)
        {
            if (SwipeDetection.instance.output == "right")
            {
                panels[panel].SetActive(false);
                panel--;
                panels[panel].SetActive(true);
                SwipeDetection.instance.output = "";
            }
        }
    }
    void Dots()
    {
        DotsGJ.GetComponent<Image>().sprite = dots[panel];
    }
    public void SetPanelToZero()
    {
        panels[panel].SetActive(false);
        panel = 0;
    }
    
}
