using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputi : MonoBehaviour
{
    public Sprite tocnosprite, netocnosprite;
    public GameObject inputField;
    public Image input;
    private string odgovor;
    public string tocno;

    public void Input()
    {
        odgovor = inputField.GetComponent<InputField>().text;
        if (odgovor.ToLower() == tocno.ToLower())
        {
            Debug.Log("tocno");
            input.sprite = tocnosprite;
        }
        else
        {
            Debug.Log("netocno");
            input.sprite = netocnosprite;
        }
    }
}
   
