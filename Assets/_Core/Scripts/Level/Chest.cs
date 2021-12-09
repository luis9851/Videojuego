using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chest : LootItem
{
    public Animator anim;
    public List<CoinJump> coinList;
    private int coinIter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void GiveLoot(){
        Debug.Log("Loot Cofre");
        anim.Play("Chest_Open");
        InvokeRepeating("GiveCoin",0,0.2f);
    }
    public void GiveCoin(){
        if(coinIter >= coinList.Count){
            CancelInvoke("GiveCoin");
            return;
        }
        coinList[coinIter].gameObject.SetActive(true);
        coinList[coinIter].Jump();
        coinIter++;
    }
    
}
