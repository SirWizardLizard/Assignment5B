/*
 * Zechariah Burrus
 * Assignment 5B
 * Handles win condition and displays win text
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWinText : MonoBehaviour {
    public DisplayKillCounter killCounterScript;
    public GameObject winText;
    // Start is called before the first frame update
    void Start() {
        killCounterScript = GameObject.FindGameObjectWithTag("DisplayKillCounter").GetComponent<DisplayKillCounter>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && killCounterScript.killCounter >= 11) {
            winText.SetActive(true);
        }
    }
}
