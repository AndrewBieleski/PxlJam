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
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
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
