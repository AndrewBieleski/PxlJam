﻿using System.Collections;
using UnityEngine;
using TeamUtility.IO;

public class CharacterControler : MonoBehaviour {

    [SerializeField]
    private PlayerID player;

    public float moveSpeed;
    private Rigidbody2D thisRigidBody;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    private Vector2 orientInput;

    public Transform rangedAttack;
    public float reloadTime;
    public float fireTrigger;
    public bool canShoot = true;
    public float shootDelay = .2f;
    public float shootSpeed = 7.0f;

    // Use this for initialization
    void Start () {
        thisRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
     //Movement:

        float deadzone = 0.25f;

        //Movement:
        moveInput = new Vector2(InputManager.GetAxisRaw("Left Stick Horizontal", player), InputManager.GetAxisRaw("Left Stick Vertical", player));
        if (moveInput.magnitude < deadzone)
            moveInput = Vector2.zero;
        moveVelocity = moveInput * moveSpeed;

        //Orientation:
        Vector2 newOrientInput = new Vector2(InputManager.GetAxisRaw("Right Stick Horizontal", player), InputManager.GetAxisRaw("Right Stick Vertical", player));
        if (newOrientInput.magnitude > deadzone)
            orientInput = newOrientInput;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(orientInput.y, orientInput.x) * 180 / Mathf.PI);

        Shooting();

    }

    void Shooting ()
    {
    
        fireTrigger = InputManager.GetAxis("Right Trigger", player);
        if (fireTrigger > 0 && canShoot)
        {
            Quaternion rotationOnCreation = Quaternion.Euler(0, 0, -90);
            Transform boltInstance = Instantiate(rangedAttack, transform.position, transform.rotation * rotationOnCreation);
            boltInstance.GetComponent<Rigidbody2D>().AddForce(orientInput * shootSpeed, ForceMode2D.Impulse);
            canShoot = false;
            Invoke("ShootDelay", shootDelay);


        }

    }
    void ShootDelay()
    {
        canShoot = true;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void FixedUpdate()
    {
        thisRigidBody.velocity = moveVelocity;
    }
}
