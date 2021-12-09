using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBom : MonoBehaviour
{
    public GameObject shootPosition;
    public GameObject bomPrefab;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log("Disparar");
            ShootBoom();
        }
    }

    public void ShootBoom(){
        Debug.Log("Player Disparo");
        Instantiate(bomPrefab,
                    shootPosition.transform.position,
                    shootPosition.transform.rotation);
    }
}
