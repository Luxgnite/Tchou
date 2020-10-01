using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField] public Vector3 offset = new Vector3(0,0,0);
    public GameObject target;
    public float timeToDie = 5f;
    public string displayText = "...";

    private SpriteRenderer spriteTarget;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        spriteTarget = target.GetComponent<SpriteRenderer>();

        text.text = displayText;

        SetAutoDestruction();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = GameManager._instance.camera.WorldToScreenPoint(target.transform.position + offset + new Vector3(0, spriteTarget.bounds.extents.y, 0));
        if (transform.position != pos)
            transform.position = pos;
    }

    void DestroyMessage()
    {
        Debug.Log("Destroy Message");
        //NotificationManager.instance.notifications.Find(
        DestroyImmediate(this.gameObject);
    }

    void SetAutoDestruction()
    {
        if (timeToDie > 0f)
        {
            StopCoroutine("FadeOut");
            StartCoroutine("FadeOut");
        }
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(timeToDie - 1f);

        text.CrossFadeAlpha(0f, 1f, false);

        StartCoroutine(DestroyMsg());
    }

    IEnumerator DestroyMsg()
    {
        yield return new WaitForSeconds(1);

        DestroyMessage();
    }

    private void OnMouseDown()
    {
        DialogueManager._instance.AfficherProchainePhrase();
    }
}
