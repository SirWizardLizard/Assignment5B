/*
 * Zechariah Burrus
 * Assignment 5B
 * Allows the player to move their mouse to control the camera
 * and doesn't allow them to go beyone 90 degree's.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public float mouseSensitivity = 100f;
    public GameObject player;
    private float verticalLookRotation = 0f;

    // Update is called once per frame
    void Update() {
        //Mouse inpuit adn assign it to floats
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotates the player with horizontal mouse input
        player.transform.Rotate(Vector3.up * mouseX);

        //Rotate the camera around the x axis with vertical mouse input
        verticalLookRotation -= mouseY;
        //Clamps rotation so the player doesn't over-rotate and look behind themselves upside down
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }

    private void OnApplicationFocus(bool focus) {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
