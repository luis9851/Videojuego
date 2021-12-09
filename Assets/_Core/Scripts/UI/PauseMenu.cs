using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   
   public void OnContinueClick(){
       Debug.Log("Pause");
       gameObject.SetActive(false);
       Time.timeScale = 1;
   }

   public void OnLevelSelectClick(){
       Debug.Log("Select Level");
       LevelManager.Ins.ShowLevelSelectMenu();

       OnContinueClick();
   }


}
