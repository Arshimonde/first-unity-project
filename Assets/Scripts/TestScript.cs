using System;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Text text;
    public bool toggle;
    public Camera cam;
    public Slider fovSlider;
    public Dropdown dropdown;
    public Transform transform;
    //Clock Variables
    public string hour;
    public string minute;
    public string second;
    // timer variables
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        toggle = false;
        cam.fieldOfView = fovSlider.value;
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle)
        {
            clock();
        }
    }

    //Clock function
    public void clock()
    {
        DateTime dateTime = DateTime.Now;
        hour = dateTime.Hour.ToString();
        minute = dateTime.Minute.ToString();
        second = dateTime.Second.ToString();
        text.text = hour + ":" + minute + ":" + second;
    }

    //Timer function 
    public void timerFunction()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            text.text = timer.ToString("#.00");
        }
        else
        {
            text.text = "0.00";
        }
    }

    // Toggle function 
    public void toggleClock()
    {
        if ( toggle )
        {
            toggle = false;
        }
        else
        {
            toggle = true;
        }
    }

    //change field of view
    public void changeFOV() {
        cam.fieldOfView = fovSlider.value;
    }

    //Dropdown function

    public void dropdownChange()
    {
        switch (dropdown.value)
        {
            case 0:
                {
                    transform.localScale = new Vector3(150, 150, 150);
                    Debug.Log(dropdown.options[0].text);
                    break;
                }
            case 1:
                {
                    transform.localScale = new Vector3(250, 250, 250);
                    Debug.Log(dropdown.options[1].text);
                    break;
                }
            case 2:
                {
                    transform.localScale = new Vector3(350, 350, 350);
                    Debug.Log(dropdown.options[2].text);
                    break;
                }
        }
    }


}

