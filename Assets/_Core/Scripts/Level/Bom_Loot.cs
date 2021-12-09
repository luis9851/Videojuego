using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom_Loot : LootItem
{
    public override void GiveLoot(){
        LevelManager.Ins.player.playerBom.gameObject.SetActive(true);
        LevelManager.Ins.player.playerGun.gameObject.SetActive(false);
    }
}
