using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CalculatorScript : MonoBehaviour
{

    public InputField numberOneInput;
    public InputField numberTwoInput;
    public Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        resultText.text = "The Result is : 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Minus Click
    public void minusClick()
    {
        int nb1 = int.Parse(numberOneInput.text);
        int nb2 = int.Parse(numberTwoInput.text);
        int result = nb1 - nb2;
        resultText.text = "The Result is : " + result.ToString();
    }

    //Plus Click
    public void plusClick()
    {
        int nb1 = int.Parse(numberOneInput.text);
        int nb2 = int.Parse(numberTwoInput.text);
        int result = nb1 + nb2;
        resultText.text = "The Result is : " + result.ToString();
    }
}
