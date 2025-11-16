using Unity.VisualScripting;
using UnityEngine;

public class SingleUsePlatform : Platform
{
    [SerializeField] AudioClip[] crushingIce;

    private void OnCollisionEnter(Collision other)
    {
        SoundEffectsManager.instance.PlayRandomSoundEffect(crushingIce, this.transform, 1);

        if (other.collider.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }

}
