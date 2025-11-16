using System;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    [SerializeField]
    Transform lastPlatform;       //die letzte generierte Platform --> zum vergleich, wo nächste gespawnt werden soll
    float currentHeight = 0;
    float ZoneOffset = 4;

    //aktuelle Spawn Range
    float currentMinY;
    float currentMaxY;

    // festgelegte Spawn Range
    const float start_minY = 1;
    const float start_maxY = 2;
    const float end_minY = 3;
    const float end_maxY = 4;

    //wann max erreicht für Spawn Range
    const float maxHeight = 2000;
    

    void Start()
    {
        currentMinY = start_minY;
        currentMaxY = start_maxY;
    }

    // Update is called once per frame
    void Update()
    {
        PlacePlatform();
        UpdateSpawnRange();
    }

    void UpdateSpawnRange()
    {
        if(HighScoreManager.instance.score % 100 != 0) return;

        float factor_t = Math.Min(HighScoreManager.instance.score / maxHeight, 1);

        currentMinY = Mathf.Lerp(start_minY, end_minY, factor_t);
        currentMaxY = Mathf.Lerp(start_maxY, end_maxY, factor_t);
    }


    float GetRandomY(float min, float max)
    {
        float y = UnityEngine.Random.Range(min, max);
        return y;
    }
    float GetRandomX()
    {
        float x = UnityEngine.Random.Range(-(GameZone.instance.width / 2), GameZone.instance.width / 2);

        return x;
    }
    
    
    void PlacePlatform()
    {
        if (lastPlatform.position.y > GameZone.instance.transform.position.y + GameZone.instance.height / 2 + ZoneOffset) return;

        currentHeight = currentHeight + GetRandomY(currentMinY, currentMaxY);
        GameObject currentPlatform = ObjectPooler.instance.SpawnFromPool(DifficultyManager.getPlatformString(), new Vector3(GetRandomX(), currentHeight, 0), Quaternion.identity);

        currentPlatform.GetComponent<Platform>()?.onSpawn();

        lastPlatform = currentPlatform.transform;     
 
        PlacePlatform();
    }

}
