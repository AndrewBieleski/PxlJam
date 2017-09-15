using System.Collections;
using UnityEngine;
using TeamUtility.IO;

public class CharacterControler : MonoBehaviour {

    private PlayerID player;

    public float moveSpeed;
    private Rigidbody2D thisRigidBody;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public Transform rangedAttack;
    public float reloadTime;
    public bool fireTrigger;

    // Use this for initialization
    void Start () {
        thisRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
     //Movement:
        moveInput = new Vector2(InputManager.GetAxisRaw("Left Stick Horizontal", player), InputManager.GetAxisRaw("Left Stick Vertical", player));
        moveVelocity = moveInput * moveSpeed;

        //Orientation:
        Debug.Log(InputManager.GetAxis("Right Stick Vertical", player) + " " + InputManager.GetAxis("Right Stick Horizontal", player));
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(InputManager.GetAxis("Right Stick Vertical", player), InputManager.GetAxis("Right Stick Horizontal", player)) * 180 / Mathf.PI);

        Shooting();

    }

    void Shooting ()
    {
    
        fireTrigger = InputManager.GetButtonDown("Right Trigger", player);
        if (fireTrigger)
        {

            Instantiate(rangedAttack, transform.position, rangedAttack.rotation);

        }

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
