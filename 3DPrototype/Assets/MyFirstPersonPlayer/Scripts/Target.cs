/*
 * Zechariah Burrus
 * Assignment 5B
 * Designates the game object as a target allowing the player to kill it.
 * Also increments kill counter on death.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public DisplayKillCounter killCounterScript;
    public float health = 50f;
    private void Start() {
        killCounterScript = GameObject.FindGameObjectWithTag("DisplayKillCounter").GetComponent<DisplayKillCounter>();
    }

    public void TakeDamage(float amount) {
        health -= amount;
        if(health <= 0) {
            Die();
            killCounterScript.killCounter += 1;
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
