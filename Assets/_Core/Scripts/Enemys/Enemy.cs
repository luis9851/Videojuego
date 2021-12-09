using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public SpriteRenderer spriteRenderer;
   public Sprite hitSprite;
   public Sprite deadSprite;
   public Animator animator;

   private void OnTriggerEnter2D(Collider2D _other) {
       if(_other.tag == GameConstants.TAG_Bullet || _other.tag == GameConstants.TAG_BOM){
           OnHit();
       }
   }
    public void OnHit(){
        if(animator != null){ animator.enabled = false; }
        /* spriteRenderer.enabled = false; */
        spriteRenderer.sprite = hitSprite;
        Invoke("SetDeadAnim",0.3f);
    }

    public void SetDeadAnim(){
        spriteRenderer.sprite = deadSprite;
        Invoke("Dead",0.3f);
    }

    private void Dead(){
        gameObject.SetActive(false);
    }

    public void OnReset(){
        if(animator != null ){
            animator.enabled = true;
        }
    }

}
