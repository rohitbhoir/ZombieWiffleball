using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public Transform startPos;
	public Transform endPos;
	
	public string ballType;
	
	public bool isPitched;
	public bool isHit;

	public Transform camTransform;
	
	private bool resetBall;
	private float ballSpeed;
	private float ballSwing;
	private float ballDrag;
	
	// Use this for initialization
	void Start () {
		transform.position = startPos.position;
		resetBall = true;
		isPitched = false;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.LookAt(camTransform);

		if(isPitched)
		{
			if(!isHit)
			{
				checkBallPos();
				//updateBallPos();
				checkInput();
			}
			rigidbody.WakeUp();
			
		}
		else
		{
			rigidbody.Sleep();
		}
	}
	
	void checkInput()
	{
		if (Input.GetKey("left"))
		{
           rigidbody.AddForce(Vector3.right * -ballSwing);
		}
        
        if (Input.GetKey("right"))
		{
            rigidbody.AddForce(Vector3.right * ballSwing);
		}
	}
	
	private void OnCollisionEnter(Collision collision) 
	{
		if(collision.collider.gameObject.name == "directionCube")
		{
			Vector3 dirVec = collision.collider.gameObject.transform.TransformDirection(Vector3.forward) ;

			GameObject.Find("newCube").transform.position = dirVec;
			//GameObject.Find("directionCube").transform.position = dirVec * 20;
			//rigidbody.AddForce(dirVec * 10);
		}
		
	}
	//set the speed and swing factors
	public void updateBallStats(float speed, float swing, float drag)
	{
		ballSpeed = speed;
		ballSwing = swing;
		ballDrag = drag;

	}
	
	public void updateBallPos()
	{
		//ball speed
		rigidbody.drag = ballDrag;
		rigidbody.AddForce(Vector3.forward * -ballSpeed * 20);
		
		
	}
	
	void checkBallPos()
	{
		//if the y position of the ball reaches the endPos reset the ball position
		if(this.transform.position.z <= endPos.position.z)
		{
			resetBallPos();
		}

	}
	
	//reset ball position
	public void resetBallPos()
	{
		rigidbody.Sleep();
		transform.position = startPos.position;
		resetBall = true;
		isPitched = false;
		
		
	}
}
