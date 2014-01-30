using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {
	
	public bool batSwinged;
	private bool stopFlag;
	private Transform initialTransform;
	
	public float batSpeed;

	
	// Use this for initialization
	void Start () {
		stopFlag = false;
		batSwinged = false;
		batSpeed = 1000;
//		Debug.Log("angles : " + transform.localEulerAngles);

	}
	
	// Update is called once per frame
	void Update () {
//		getInput();
		if(batSwinged)
		{
			batSwinged = false;
			swingBat();
		}
	}
	
	void getInput()
	{
//		if (Input.GetKey("space"))
//		{
//			//swing the bat
//             batSwinged = true;
//		}
	}
	
	public void resetBat()
	{
		stopFlag = false;
		batSwinged = false;
		gameObject.SampleAnimation(animation.clip,0);
		//Debug.Log("resetting bat...");
		//transform.localEulerAngles = new Vector3(0.0f,359.6f,320.4f);
		//transform.position = initialTransform.position;
		//transform.eulerAngles = initialTransform.eulerAngles;
	}
	
	void swingBat()
	{
		animation["BatAnim"].speed = 3;
		animation.Play();
		resetBat();
		//Testing git
//		if(transform.localEulerAngles.y < 130 && !stopFlag)
//		{
//			stopFlag = true;
//			resetBat();
//		}
//
//		else
//		{
//			transform.Rotate(Vector3.up * Time.deltaTime * -batSpeed);
//			//Debug.Log("angles : " + transform.localEulerAngles);
//		}
		
	}
}
