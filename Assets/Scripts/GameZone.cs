using System;
using UnityEngine;

public class GameZone : MonoBehaviour
{
    Camera cam;
    float width;
    float height;
    [SerializeField] float offset;      //offset, damit er erst später rüberteleportiert und man noch ein wenig aus dem Screen raus kann

    void Awake()
    {
        cam = FindFirstObjectByType<Camera>();
        if (cam == null)
        {
            Debug.LogError("No camera found!");
            return;
        }

        SetToCameraSize();
    }

    void SetToCameraSize()
    {
        //Höhe in Welt-Einheiten
        height = cam.orthographicSize * 2f;
        //Seitenverhältnis
        width = height * cam.aspect;
        //Scale anpassen (weil Plane 10x10)
        transform.localScale = new Vector3(width / 10f, 1f, height / 10f);

        Debug.Log(width);
    }

    void Update()
    {
        CheckPlayerBoundary(PlayerController.instance.transform.position.x);
        CheckGameOver(PlayerController.instance.transform.position.y);
        
    }
    

    void CheckPlayerBoundary(float playerPosition)
    {
        //Debug.Log(playerPosition);
        if (this.width / 2 + offset < playerPosition)
        {
            PlayerController.instance.transform.position = new Vector3(-(this.width / 2), PlayerController.instance.transform.position.y, PlayerController.instance.transform.position.z);
        }
        else if(-((this.width / 2)+ offset) > playerPosition)
        {
            PlayerController.instance.transform.position = new Vector3(this.width / 2, PlayerController.instance.transform.position.y, PlayerController.instance.transform.position.z);

        }

    }

    void CheckGameOver(float playerPosition)
    {
        //Debug.Log(playerPosition);
        if (this.transform.position.y - height/2 > playerPosition)
        {
            PlayerController.instance.isAlive = false;
            Debug.Log("Game OVER");
        }

    }
}
