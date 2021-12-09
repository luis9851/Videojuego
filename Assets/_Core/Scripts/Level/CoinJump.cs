using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinJump : MonoBehaviour
{
    public GameObject particulas;
    public void Jump(){
        transform.DOJump(LevelManager.Ins.coinsText.transform.position,1,1,0.45F)
        .OnComplete(OnCoinJumpComplete);
    }
    public void OnCoinJumpComplete(){
        LevelManager.Ins.AddCoins();
        Instantiate(particulas,
                    transform.position,
                    transform.rotation);
        gameObject.SetActive(false);
    }
}
