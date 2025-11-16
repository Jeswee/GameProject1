using UnityEngine;

public class MainMenuZone : MonoBehaviour
{
    public static MainMenuZone instance;
    [SerializeField] Camera cam;
    public float width;
    public float height;
    [SerializeField] float screenOffset = 0.2f;     //da Shader die Seiten wackeln lääst --> damit Screen wirklich ausgefüllt ist

    void Awake()
    {
        instance = this;
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
        height = cam.orthographicSize * 2f + screenOffset;
        //Seitenverhältnis
        width = height * cam.aspect + screenOffset;
        //Scale anpassen (weil Plane 10x10)
        transform.localScale = new Vector3(width / 10f, 1f, height / 10f);

        //Debug.Log(width);
    }

    

}
