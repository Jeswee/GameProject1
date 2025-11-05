using UnityEngine;

public class GameZone : MonoBehaviour
{
    Camera cam;

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
        float height = cam.orthographicSize * 2f;
        //Seitenverhältnis
        float width = height * cam.aspect;
        //Scale anpassen (weil Plane 10x10)
        transform.localScale = new Vector3(width / 10f, 1f, height / 10f);
    }


    //
}
