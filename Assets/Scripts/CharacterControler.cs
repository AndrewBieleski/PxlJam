using System.Collections;
using UnityEngine;
using TeamUtility.IO;

public class CharacterControler : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D thisRigidBody;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public Transform rangedAttack;
    public float reloadTime;

    // Use this for initialization
    void Start () {
        thisRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
     //Movement:
        moveInput = new Vector2(InputManager.GetAxisRaw("Left Stick Horizontal", PlayerID.One), InputManager.GetAxisRaw("Left Stick Vertical", PlayerID.One));
        moveVelocity = moveInput * moveSpeed;

        //Orientation:
        Debug.Log(InputManager.GetAxis("Right Stick Vertical", PlayerID.One) + " " + InputManager.GetAxis("Right Stick Horizontal", PlayerID.One));
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(InputManager.GetAxis("Right Stick Vertical", PlayerID.One), InputManager.GetAxis("Right Stick Horizontal", PlayerID.One)) * 180 / Mathf.PI);
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
