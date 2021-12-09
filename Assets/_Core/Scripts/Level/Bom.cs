using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    Rigidbody2D rd;
    public float speed;
    public GameObject bom;
    
    private void OnTriggerEnter2D(Collider2D _other) {
        if(_other.tag == GameConstants.TAG_Enemy || _other.tag == GameConstants.TAG_GROUND){
            Instantiate(bom,
                        transform.position,
                        transform.rotation);
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = transform.right * speed;
        /* rigidbody2D.velocity = rd.AddForce(new Vector2(0,speed),ForceMode2D.Impulse); */
    }
}
