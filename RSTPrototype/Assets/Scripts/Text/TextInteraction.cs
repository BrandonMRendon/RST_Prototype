using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInteraction : MonoBehaviour
{
    public Text text;
    public string messagetoPrintp;
    public bool isIn, messageBegun;


    string message;
    string[] messageToPrint;
    bool inText;
    
    int messageLength, messageIndex;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            isIn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isIn = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        inText = false;
        messageIndex = 0;
        
    }
    public void startText(string message)
    {
        messageToPrint = message.Split('$');
        inText = true;
        messageLength = messageToPrint.Length;
        text.text = messageToPrint[messageIndex];
        messageIndex += 1;
    }
    void clearText()
    {
        text.text = "";
        messageToPrint = null;
        inText = false;
        messageIndex = 0;
        messageLength = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn && !messageBegun)
        {
            messageBegun = true;
            startText(messagetoPrintp);
        }
        if (inText && Input.GetKeyDown("space"))
        {
            if(messageIndex < messageLength)
            {
                text.text = messageToPrint[messageIndex];
                messageIndex += 1;
            }
            else
            {
                clearText();

            }
        }
    }
}
