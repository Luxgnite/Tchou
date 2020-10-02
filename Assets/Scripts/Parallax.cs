using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //Length : largeur du sprite mis en parallax
    //startPosition : position initial de l'objet en parallax
    private float length, startPosition;
    public Camera camera;
    [Range(-1f, 1f)]
    public float parallaxEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        //Si l'objet est moins grand que la largeur de l'aire de la caméra, on défini la largeur à prendre en compte comme étant celle de la caméra
        if (length < (camera.orthographicSize * camera.aspect * 2))
            length = camera.orthographicSize * camera.aspect * 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Calcul de décalage par rapport au déplacement de la caméra
        float temp = (camera.transform.position.x  - transform.position.x);
        float distance = (GameManager._instance.parallaxSpeed * parallaxEffect);

        //Déplacement de l'objet en parallax
        transform.position = new Vector3(transform.position.x + distance * Time.deltaTime, transform.position.y, transform.position.z);

        //Détermine si l'objet disparaît de l'écran ; si c'est le cas, on le replace d'un côté pour boucler de nouveau
        if (temp > + length)
        {
            transform.position = new Vector3(camera.transform.position.x + length, transform.position.y, transform.position.z);
            startPosition = transform.position.x;
        }
        else if (temp < - length)
        {
            transform.position = new Vector3(camera.transform.position.x - length, transform.position.y, transform.position.z);
            startPosition = transform.position.x;
        }
    }
}
