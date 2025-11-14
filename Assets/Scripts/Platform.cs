using UnityEngine;

public class Platform : MonoBehaviour
{
    public float desiredJumpHeight;
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
            snow.SetActive(true);
        } 
        else
        {
            snow.SetActive(false);
        }
    }
}
