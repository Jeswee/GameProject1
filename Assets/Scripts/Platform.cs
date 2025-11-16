using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpMultiplier = 1;
    [SerializeField] GameObject snow;
    float offset = 0.2f;


    //Schnee an/ aus stellen --> Referenz auf RegionManager --> an Region anpassen  --> wenn Platform.y <= Region.min.Height --> switch Schnee


    void Awake()
    {
        
    }

    void Update()
    {
        CheckDespawn();
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

    public void CheckDespawn()
    {
        if(this.transform.position.y < GameZone.instance.transform.position.y - GameZone.instance.height / 2 - offset)
        {
            gameObject.SetActive(false);
        }
        
    }
}
