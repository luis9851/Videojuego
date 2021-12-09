using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveEnemy : MonoBehaviour
{
    public float timeAnim;
    public GameObject enemy;
    public GameObject starPosition;
    public GameObject endPosition;
    
    void Start()
    {
        enemy.transform.position = starPosition.transform.position;
        enemy.transform.DOMove(endPosition.transform.position, timeAnim)
        .SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

}
