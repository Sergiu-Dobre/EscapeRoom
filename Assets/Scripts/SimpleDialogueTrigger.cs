using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogueTrigger : MonoBehaviour
{

    public SimpleDialogue dialogue;

    public void TriggerDialogue()
    {
        SimpleDialogueSystem.Instance.StartDialogue(dialogue);
    }

}

