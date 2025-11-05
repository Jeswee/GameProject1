using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] private Transform _player;
    [SerializeField] float offset = 3.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Cam bewegt sich hoch --> so dass letzte Platform unterster Bereich in GameZone/ Viewport ist
    void LateUpdate()
    {
        if (this.transform.position.y < _player.transform.position.y + offset)
        {
            transform.position = new Vector3(transform.position.x, _player.transform.position.y + offset, transform.position.z);
        }
    }
}
