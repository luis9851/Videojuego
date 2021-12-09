using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public SpriteRenderer spriteRender;
    public Sprite spriteHitBlnco;
    public Animator animator;
    private int lifes = 3;
    private const int MAX_LIFE = 3;
    public GameObject playerGun;
    public GameObject playerBom;

    public void ResetPlayer(){
        lifes = MAX_LIFE;
        playerGun.gameObject.SetActive(false);
        playerBom.gameObject.SetActive(false);
    }

    //Detectar colision
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            Debug.Log("Enemy");
            OnDamage();
        }
    }
    private bool esInmune = false;
    private void OnDamage(){
        if(esInmune){ return; }
        //vidas
        lifes--;
        if(lifes < 0){ 
            LevelManager.Ins.GameOver();
            playerMovement.BlockMovement(true);
            playerMovement.StopMovement();
            animator.enabled = false;
            spriteRender.enabled = false;
            return; 
        }
        LevelManager.Ins.OnPlayerDamage(lifes);
        Debug.Log("Player lifes: "+lifes);
        //inmune al daño
        esInmune = true;
        //Bloquear movimiento
        playerMovement.BlockMovement(true);
        playerMovement.StopMovement();
        //Aplicar animacion de hit
        animator.enabled = false;
        spriteRender.sprite = spriteHitBlnco;
        //Empujon del personaje
        playerMovement.DamageForce();
        //Parpadeo de personaje
        spriteRender.enabled = false;
        InvokeRepeating("Parpadeo",0, 0.3f);
        //Regresar a la normalidad
        Invoke("BackToNormal",2);
    }

    private void BackToNormal(){
        esInmune = false;
        playerMovement.BlockMovement(false);
        animator.enabled = true;
        CancelInvoke("Parpadeo");
        spriteRender.enabled = true;
    }

    private void Parpadeo(){
        spriteRender.enabled = !spriteRender.enabled;
    }
}
