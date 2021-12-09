using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour
{
    public GameObject lootPosition;
    public bool isActive = false;
    public bool isLooted = false;
    public virtual void GiveLoot() {}
    public bool removeAfterLoot = false;
    private void OnTriggerEnter2D(Collider2D _other) {
        isActive = true;
        if(isLooted){ return; }
        if(_other.tag != GameConstants.TAG_PLAYER){ return; }
        Debug.Log("Loot colision Player");
        ///Prender Loot_UI
        LevelManager.Ins.lootUI.gameObject.SetActive(true);
        LevelManager.Ins.lootUI.transform.position = lootPosition.transform.position;

    }
    private void OnTriggerExit2D(Collider2D _other) {
        if(isLooted){ return; }
        if(_other.tag != GameConstants.TAG_PLAYER){ return; }
        isActive = false;
        Debug.Log("Loot colision Player");
        ///Apagar Loot_UI
        LevelManager.Ins.lootUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if(!isActive){ return; }
        if(isLooted){ return; }
        if (Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Loot presionado");
            GiveLoot();
            isLooted = true;
            LevelManager.Ins.lootUI.gameObject.SetActive(false);

            if(removeAfterLoot){
                gameObject.SetActive(false);
            }
        }
    }
}
