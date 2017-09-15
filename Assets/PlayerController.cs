using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public float speed = 1f;
    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
        }
        else if (horizontal < 0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
        }
        if (vertical > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
        }
        else if (vertical < 0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed);
        }
    }
}
