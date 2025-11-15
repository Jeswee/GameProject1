using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpMultiplier = 1;
    [SerializeField] GameObject snow;


    //Schnee an/ aus stellen --> Referenz auf RegionManager --> an Region anpassen  --> wenn Platform.y <= Region.min.Height --> switch Schnee


    void Awake()
    {
        
    }

    public void onSpawn()
    {
        Region currentRegion = RegionManager.instance.currentRegion;
        if(currentRegion.regionType == RegionType.EARTH || currentRegion.regionType == RegionType.SKY)
        {
            snow?.SetActive(true);      //? = nur wenn Snow überhaupt vorhanden
        } 
        else
        {
            snow?.SetActive(false);
        }
    }
}
