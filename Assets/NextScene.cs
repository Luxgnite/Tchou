using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{

    public string sceneName;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager._instance.ChangeScene(sceneName);
    }
}
