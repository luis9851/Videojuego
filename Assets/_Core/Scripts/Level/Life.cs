using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Image image;
    public Sprite lifeOff;
    public Sprite lifeOn;
    public void ApagarVida(){
        image.sprite = lifeOff;
    }

    public void PrenderVida(){
        image.sprite = lifeOn;
    }

}
