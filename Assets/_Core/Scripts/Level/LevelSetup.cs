using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    public GameObject playerSpawnPosition;
    void Start()
    {
        LevelManager.Ins.player.transform.position = 
        playerSpawnPosition.transform.position;
    }
}
