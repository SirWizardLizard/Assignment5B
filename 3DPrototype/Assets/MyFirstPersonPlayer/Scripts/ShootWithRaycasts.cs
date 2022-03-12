/*
 * Zechariah Burrus
 * Assignment 5B
 * Allows the player to shoot at targets using a raycast
 * Also scales what's hit down for fun.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRaycasts : MonoBehaviour {
    public float damage = 10f;
    public float range = 100f;
    public float hitForce = 15f;
    public Camera cam;

    public ParticleSystem muzzleFlash;
    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Fire1")) { Shoot(); }
    }

    void Shoot() {
        muzzleFlash.Play();

        RaycastHit hitInfo;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range)) {
            Debug.Log(hitInfo.transform.gameObject.name);

            Target target = hitInfo.transform.gameObject.GetComponent<Target>();
            if(target != null) {
                target.TakeDamage(damage);
                Vector3 targetScale = hitInfo.transform.localScale;
                hitInfo.transform.localScale = new Vector3(targetScale.x - 1, targetScale.y - 1, targetScale.z - 1);
            }

            if(hitInfo.rigidbody != null) {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
