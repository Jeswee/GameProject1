using System;
using UnityEngine;

public class MovingPlatform : Platform
{
    private enum direction { LEFT, RIGHT }
    direction dir = direction.LEFT;
    [SerializeField] float vel = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(this.transform.position.x) > Math.Abs(GameZone.instance.transform.position.x - GameZone.instance.width / 2))
        {
            switch (dir)
            {
                case direction.LEFT:
                    dir = direction.RIGHT;
                    vel = 2;
                    break;
                case direction.RIGHT:
                    dir = direction.LEFT;
                    vel = -2;
                    break;
            }
        }

        this.transform.position += new Vector3(vel* Time.deltaTime, 0, 0);
    }
}
