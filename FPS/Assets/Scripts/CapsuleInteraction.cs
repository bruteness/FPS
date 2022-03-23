using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsuleInteraction : MonoBehaviour, IDamage {
    public int health = 100;
    public Slider slider;
    
    public void TakeDamage() {
        health -= 10;
        health = health < 0 ? 0 : health;
        Debug.Log("Cube health " + health);
        slider.gameObject.SetActive(true);
        slider.value = (float)health / 100f;
    }
}