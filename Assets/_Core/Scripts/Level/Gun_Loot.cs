using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Loot : LootItem
{
    // Start is called before the first frame update

    public override void GiveLoot(){
        LevelManager.Ins.player.playerGun.gameObject.SetActive(true);
        LevelManager.Ins.player.playerBom.gameObject.SetActive(false);
    }
    
}
