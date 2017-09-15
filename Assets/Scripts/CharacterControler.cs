using System.Collections;
using UnityEngine;
using TeamUtility.IO;

public class CharacterControler : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D thisRigidBody;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

	// Use this for initialization
	void Start () {
        thisRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector2(InputManager.GetAxisRaw("Left Stick Horizontal", PlayerID.One), InputManager.GetAxisRaw("Left Stick Vertical", PlayerID.One));
        moveVelocity = moveInput * moveSpeed;
	}

    void FixedUpdate()
    {
        thisRigidBody.velocity = moveVelocity;
    }
}
