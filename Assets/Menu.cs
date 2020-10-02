using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    private void OnMouseDown()
    {
        GameManager._instance.ChangeScene("Scenes/TrainTest");
    }
}
