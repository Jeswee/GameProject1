using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] public float gravity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0f, gravity, 0f);
    }
}
