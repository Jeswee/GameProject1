using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Schwierigkeit --> wie groß Distanz der Plattformen minimal sein muss + wie viele Platformen max. in Game Zonegespawnt werden dürfen + Menge an Upgrades pro 50m

    //Arten von Platformen --> in einem Object Pool         (PowerUps separater Pool oder Instantiated?)
        //- moving Platforms x-Achse (maybe auch y, oder x&y)
        //- one-time use platforms
        //- bouncy (jump higher) platforms
        //- normal platforms


    //wenn Y-Koordinate <= 100 --> nur 100% normale Plattformen & Schwierigkeit gering
    //wenn Y-Koord. <= 200 erreicht --> 20% bewegende Plattformen + 80% normale Plattformen
    //wenn Y <= 


}
