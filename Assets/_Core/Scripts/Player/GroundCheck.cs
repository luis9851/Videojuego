using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    
    public bool isGrounded = false;
    public SpriteRenderer spriteRender;
    public PlayerMovement playerMovement;

    void Update()
    {
        if(isGrounded){
            spriteRender.color = Color.green;
        }else{
            spriteRender.color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D _collider) {
        /* isGrounded = true; */
        /* isGrounded = _collider != null && _collider.tag == GameConstants.TAG_GROUND; */
        if(_collider.tag != GameConstants.TAG_GROUND){ return; }
            isGrounded = true;
            playerMovement.OnLandEvent();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag != GameConstants.TAG_GROUND){ return; }
        isGrounded = false;
    }
}
