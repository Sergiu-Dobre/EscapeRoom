using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using static Dialogue;

public class AIBot : MonoBehaviour
{

    public float interactionRange = 7f;

    private void Start()
    {

        FindAnyObjectByType<DialogueManager>().StartDialogue(Conversation());

    }

    private DialogueSection Conversation()
    {
       string localName = "AIBot";

        Monologue no = new Monologue(localName, "I respect your choice human");

        Monologue yes = new Monologue(localName, "Well let me tell you.");


            Choices b = new Choices(localName, "Would you like to hear more?", ChoiceList(Choice("No", no), Choice("Yes", yes)));
        Monologue a = new Monologue(localName, "I am here to assist you", b);

        return a;
    
    }

}
