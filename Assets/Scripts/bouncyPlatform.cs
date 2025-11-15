using UnityEngine;

public class bouncyPlatform : Platform
{

    void Awake()
    {
        desiredJumpHeight = PlayerController.instance.desiredJumpHeight * 2;
    }
    
}
