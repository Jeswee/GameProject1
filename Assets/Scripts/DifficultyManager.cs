using System;
using Unity.VisualScripting;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{

    // Platform-Typ     Startwichtigkeit (bei Höhe 0)       Ziel Wichtigkeit (bei max Höhe)         gewünschte max Höhe
    // Standard         100% - 15% - 3000
    // moving           0% - 30% - 2500
    // bouncy           0% - 15% - 1000
    // singleUse        0% - 40% - 3000

    static float start = 0;
    static float standard;
    static float moving;
    static float bouncy;
    static float singleUse;
    
    void Start()
    {
        getPlatformString();
    }


    void Update()
    {
        
    }

    // ====== PLATFORM LOGIC =======


    static float GetPercentage(float startP, float maxP, float maxHeight, float currentHeight)        //Prozentsatz von Plattformen die auftauchen solle
    {
        float factor_t = Math.Min(currentHeight/ maxHeight, 1);
        return Mathf.Lerp(startP, maxP, factor_t);
    }

    // movingRangeStart = 0
    // movingRangeEnd = aktuelleProzentzahl
    // bouncyRangeStart = movingRangeEnd + 1
    // bouncyRangeEnd = bouncyRangeStart + aktuelleProzentzahl

    // randomZahl < 30 --> randomZahl < A+B (30+30 = 60%) --> rZahl < A+B+C

    public static String getPlatformString()
    {
            UpdatePercentages();
            

            //Debug.Log("standard:  " + standard + "    " + "moving:  " + moving);

            float randomInt = UnityEngine.Random.Range(0, 100);

            if(randomInt <= standard) return "standard";
            if(randomInt <= moving) return "moving";
            if(randomInt <= bouncy) return "bouncy";
            if(randomInt <= singleUse) return "singleUse";


            return "standard";
    }

    static void UpdatePercentages()
    {
        if(HighScoreManager.score % 20 != 0) return;

        start = 0;
        standard = start + GetPercentage(100, 5, 1900, GameZone.instance.transform.position.y);
        moving = standard + GetPercentage(0, 31, 1300, GameZone.instance.transform.position.y);
        bouncy = moving + GetPercentage(0, 12, 700, GameZone.instance.transform.position.y);
        singleUse = bouncy + GetPercentage(0, 42, 1900, GameZone.instance.transform.position.y);
    }
}
