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

    public List<Region> regions = new List<Region>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void checkCurrentRegion()
    {

    }
}
