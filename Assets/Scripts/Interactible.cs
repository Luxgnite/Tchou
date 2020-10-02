using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public Dialogue dialogue;
    public string texteAide;

    private Message instanceTexteAide;
    private void OnMouseDown()
    {
        DialogueManager._instance.ChargerDialogue(dialogue, this.gameObject);
    }

    private void OnMouseEnter()
    {
        instanceTexteAide = Instantiate(DialogueManager._instance.messagePrefab, new Vector3(0, 0, -1000), Quaternion.identity);
        instanceTexteAide.gameObject.transform.SetParent(DialogueManager._instance.messageCanvas.transform, false);

        instanceTexteAide.typeWrite = false;
        instanceTexteAide.displayText = "<i>"+texteAide+"</i>";

        instanceTexteAide.target = this.gameObject;
        instanceTexteAide.timeToDie = 0f;
    }

    private void OnMouseExit()
    {
        instanceTexteAide.timeToDie = 1f;
        instanceTexteAide.SetAutoDestruction();
    }
}
