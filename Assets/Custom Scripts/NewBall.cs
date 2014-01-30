using UnityEngine;
using System.Collections;

public class NewBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(Vector3.up * 1000);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
