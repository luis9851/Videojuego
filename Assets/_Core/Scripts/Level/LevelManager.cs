using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Ins;
    public int coins = 0;
    public TextMeshProUGUI coinsText;
    public List<Life> lifeList;
    public GameObject gameOverMenu;
    public GameObject levelCompleteMenu;
    public GameObject levelSelectMenu;
    public GameObject loadingMenu;
    public GameObject PauseMenu;
    public GameObject lootUI;
    public Player player;

    public void ResetGame(){
        player.ResetPlayer();
        player.playerMovement.BlockMovement(false);
        player.animator.enabled = true;
        player.spriteRender.enabled = true;
        for(int i=0;i< lifeList.Count;i++){
            lifeList[i].PrenderVida();
        }
        
    }
    private void Awake() {
        Ins = this;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SceneManager.sceneLoaded += OnSceneLoaded;    
    }

    private void OnSceneUnloaded(Scene scene){
        SceneManager.LoadScene("Level_"+nivelActual, LoadSceneMode.Additive);
    }

    private void OnSceneLoaded(Scene scene,LoadSceneMode modo){
        loadingMenu.gameObject.SetActive(false);
    }

    public void OnLevelComplete(){
        Debug.Log("Level complete!!!");
        Invoke("OnLevelCompleteDelay",1);

    }

    public void ShowLevelSelectMenu(){
        levelSelectMenu.gameObject.SetActive(true);
    }

    public void ShowPauseMenu(){
        Time.timeScale = 0;
        PauseMenu.gameObject.SetActive(true);
    }

    private void OnLevelCompleteDelay(){
        levelCompleteMenu.gameObject.SetActive(true);
    }

    public void AddCoins(){
        coins++;
        coinsText.text = coins.ToString();
        /* Debug.Log("LevelManager Coins: "+coins) */;
    }

    
    public void OnPlayerDamage(int _lifes){
        if(_lifes < 0){ return; }
        lifeList[_lifes].ApagarVida();
    }
  

    ///////////////////////////////////////////////////////////////////
    /// Game Over
    
    public void GameOver(){
        gameOverMenu.gameObject.SetActive(true);
    }

    public void OnRetryClick(){
        ResetGame();
        gameOverMenu.gameObject.SetActive(false);
        LoadLevel(nivelActual);
    }

    ///////////////////////////////////////////////////////////////////
    /// Level
    private int nivelActual = 1;
    public void LoadLevel(int _levelNumber){
        Debug.Log("Nivel: "+ _levelNumber);
        loadingMenu.gameObject.SetActive(true);
        
        SceneManager.UnloadSceneAsync("Level_"+nivelActual);
        
        nivelActual = _levelNumber;
        
        levelCompleteMenu.gameObject.SetActive(false);
        levelSelectMenu.gameObject.SetActive(false);
    }
}
