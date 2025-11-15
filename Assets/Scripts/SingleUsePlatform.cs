using Unity.VisualScripting;
using UnityEngine;

public class SingleUsePlatform : Platform
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }

}
