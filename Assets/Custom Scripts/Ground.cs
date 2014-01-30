using UnityEngine;
using System.Collections;

public class Ground: MonoBehaviour {
	
	public Transform startGround;
	public Transform endGround;
	
	// Use this for initialization
	void Start () {
		float groundDistance;
		float start = startGround.position.y;
		float end = endGround.position.y;
		groundDistance = Mathf.Sqrt(Mathf.Pow(start - end,2));

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
}
