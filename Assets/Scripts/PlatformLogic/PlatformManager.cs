using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    [SerializeField]
    Transform lastPlatform;       //die letzte generierte Platform --> zum vergleich, wo nächste gespawnt werden soll
    float currentHeight = 0;
    float ZoneOffset = 4;
    float minY = 1;
    float maxY = 4;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlacePlatform();
    }


    float GetRandomY(float min, float max)
    {
        float y = Random.Range(min, max);
        return y;
    }
    float GetRandomX()
    {
        float x = Random.Range(-(GameZone.instance.width / 2), GameZone.instance.width / 2);

        return x;
    }
    
    
    void PlacePlatform()
    {
        if (lastPlatform.position.y > GameZone.instance.transform.position.y + GameZone.instance.height / 2 + ZoneOffset) return;

        currentHeight = currentHeight + GetRandomY(minY, maxY);
        GameObject currentPlatform = ObjectPooler.instance.SpawnFromPool(DifficultyManager.getPlatformString(), new Vector3(GetRandomX(), currentHeight, 0), Quaternion.identity);

        currentPlatform.GetComponent<Platform>()?.onSpawn();

        lastPlatform = currentPlatform.transform;     
 
        PlacePlatform();
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




    //===========================================
        //Platform Spawner:
            // x-Achse --> zufälliger Wert zwischen GameZone.width/2 & -GameZone.width/2
            // y-Achse --> zufälliger Wert zwischen desiredJumpHeight & mindestAbstandFürPlattformSpawn

            //wenn unterhalb von GameZone.transform.position - GameZone.height/2 + offset  --> dann despawn

            // wenn letzte gespawnte Plattform.y < gameZone.y + gameZone.height/2 + offset
            // zu Start() --> letzte PLatform = Boden

}
