using UnityEngine;

public class bouncyPlatform : Platform
{
    [SerializeField] AudioClip[] cartoonBoing;

    void OnCollisionEnter(Collision other)
    {
        SoundEffectsManager.instance.PlayRandomSoundEffect(cartoonBoing, this.transform, 1);
    }
}
