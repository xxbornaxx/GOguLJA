using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public static SwipeDetection instance;

    Vector2 startPos;
    Vector2 currentPos;
    Vector2 endPos;
    private bool stopTouch=false;

    public float swipeRange, tapRange;
    public string output; // "left", "right", "up", "down", "tap"

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        Swipe();
    }
    public void Swipe()
    {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) //ako igrač dotakne ekran uzmi poziciju početnog dodira
            {
                startPos = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) //ako se dodir ekrana pomakne
            {
                currentPos = Input.GetTouch(0).position;  //uzimaj trenutnu poziciju dodira
                Vector2 distance = currentPos - startPos;  //vector koji pokazuje od pocetka dodira do trenutnog
                if (!stopTouch) //kada se ekran prestane dirat
                {
                    // promijeni output ovisno o tome u kojem smijeru ide vector
                    if (distance.x < -swipeRange)
                    {
                        output = "left";
                        stopTouch = true;
                    }
                    else if (distance.x > swipeRange)
                    {
                        output = "right";
                        stopTouch = true;
                    }
                    else if (distance.y < -swipeRange)
                    {
                        output = "down";
                        stopTouch = true;
                    }
                    else if (distance.y > swipeRange)
                    {
                        output = "up";
                        stopTouch = true;
                    }
                }

            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) //ovdje se prikazuje da li je dodir prestao
            {
                stopTouch = false;
                endPos = Input.GetTouch(0).position;
                Vector2 distance = endPos - startPos;
                if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange) //detektiranje kratkog dodira
                {
                    output = "tap";
                }
            }
        
    }
}

