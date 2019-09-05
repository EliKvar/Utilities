using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputManager : MonoBehaviour
{
    public Text outText;
    public Button enterButton;
    public InputField textIn;


    void Start()
    {
        outText.text = "";
        
    }

    public void EnterPressed()
    {
        outText.text  =Utilities.ProcessText(textIn.text);

    }



    void Update()
    {
        
    }
}
