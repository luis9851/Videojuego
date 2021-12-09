using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject shootPosition;
    public GameObject bulletPrefab;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log("Disparar");
            Shoot();
        }
    }

    public void Shoot(){
        Debug.Log("Player Disparo");
        Instantiate(bulletPrefab,
                    shootPosition.transform.position,
                    shootPosition.transform.rotation);
    }

}
