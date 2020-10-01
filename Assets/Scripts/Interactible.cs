using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnMouseDown()
    {
        DialogueManager._instance.ChargerDialogue(dialogue, this.gameObject);
    }
}
