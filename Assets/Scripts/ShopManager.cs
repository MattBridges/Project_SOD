using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopItem selectedItem;
    public AudioClip hasEnoughCredits;
    public AudioClip notEnoughCredits;
    public int healAmount;
    private GmManager gm;
    private SoundManager sm;

    private void Start()
    {
        gm = FindObjectOfType<GmManager>();
        sm = FindObjectOfType<SoundManager>();
    }

    public void SelectTurret(ShopItem item)
    {
        if(item.cost <= gm.playerCredits)
        {
            selectedItem = item;
            sm.OneShot(hasEnoughCredits);
        }
        else
        {
            selectedItem = null;
            sm.OneShot(notEnoughCredits);
            Debug.Log("Not Enough Credits");
        }
    }



    public void CompletePurchase(ShopItem item)
    {
        gm.RemoveCredits(item.cost);
        selectedItem = null;
    }

  
}
