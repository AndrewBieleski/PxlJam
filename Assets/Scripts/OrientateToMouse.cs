using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class OrientateToMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        Debug.Log(InputManager.GetAxis("Right Stick Vertical", PlayerID.One) + " " + InputManager.GetAxis("Right Stick Horizontal", PlayerID.One));
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(InputManager.GetAxis("Right Stick Vertical", PlayerID.One), InputManager.GetAxis("Right Stick Horizontal", PlayerID.One)) * 180 / Mathf.PI);
        //Get the Screen positions of the object
        //Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);

		//Get the Screen position of the mouse
		//Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

		//Get the angle between the points
		//float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

		//Ta Daaa
		//transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
