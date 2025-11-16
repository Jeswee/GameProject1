using System;
using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour
{
    //REGIONS
    //0-250 earth, 250-500 sky, 500-750 atmosphere, ab 750 space


    // Schnee von Platformen entfernen (gibt nur Info über Region an Pflatform Manager weiter)
    // Deko pro Region switchen
    // Schnee nur in earth & sky
    // Musik ändern
    // Hintergrundfarbe der GameZone langsam anpassen

    public static RegionManager instance;
    public List<Region> regions = new List<Region>();
    int level = 0;
    [SerializeField] int regionSize = 250;
    public Region currentRegion;


    //FARBWECHSEL AUF REGION SWITCH



    void Start()
    {
        instance = this;
        currentRegion = regions[level];
    }

    // Update is called once per frame
    void Update()
    {
        if(GameZone.instance.transform.position.y - (level*regionSize) >= regionSize && level != 3)        //Game Zone immer erst wechseln, nachdem 250 weiter gegeangen ist
        {
            level++;
            level = Math.Clamp(level, 0, 3);    //just to be sure :))
            currentRegion = regions[level];

            //ColorLerp();
        }
    }

    // GameZone.instance.GetComponent<Material>().SetVector("_Color_A_Albedo", Vector)

    void ColorLerp()
    {
        //TODO: Lerp between colors
    }

}
