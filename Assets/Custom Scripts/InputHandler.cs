using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour 
{   
	public static int swipeDir = 0;

	// Swipe related
	private float             comfortZone = 500.0f; //Experiment with these values to get desired result
	private float             minSwipeDist = 10.0f; //Experiment with these values to get desired result
	private float             maxSwipeTime = 15f;    //Experiment with these values to get desired result
	private enum             eSwipeDirection 
	{
		None,
		Left,
		Right,
		Up,
		Down,
	}
	private float startTime;
	private Vector2 startPos;
	private bool couldBeSwipe;   
	private eSwipeDirection      m_LastSwipe = InputHandler.eSwipeDirection.None; 
	private Vector2              m_HorizontalSwipeVector;
	private Vector2              m_VerticalSwipeVector;


	
	public Bat batScript;

	void Start()
	{
		batScript = GetComponent<Bat>();
	}

	void Update () 
	{
		HandleTouchGestureInput();

		processInput();

	}

	void processInput()
	{
		if(m_LastSwipe == eSwipeDirection.Left || m_LastSwipe == eSwipeDirection.Right)
		{
			batScript.batSwinged = true;
			m_LastSwipe = eSwipeDirection.None;
		}
	}

	private void HandleTouchGestureInput()
	{  
		if(Input.touches.Length == 1)
		{
			//Finger data
			Touch touchedFinger = Input.touches[0];
			
			switch(touchedFinger.phase)
			{         
			case TouchPhase.Began: // stop/start swipe
				m_LastSwipe = InputHandler.eSwipeDirection.None;       
				couldBeSwipe = true;
				startPos = touchedFinger.position;          
				startTime = Time.time;
				break;
			case TouchPhase.Moved: //Detection if not a swipe
				if (Mathf.Abs(touchedFinger.position.y - startPos.y) > comfortZone) 
				{
					Debug.Log("Not a swipe. Swipe is " + (int)(Mathf.Abs(touchedFinger.position.y - startPos.y) - comfortZone) + "px outside the comfort zone.");
					couldBeSwipe = false;  
				}
				
				if (Mathf.Abs(touchedFinger.position.x - startPos.x) > comfortZone) 
				{
					Debug.Log("Not a swipe. Swipe is " + (int)(Mathf.Abs(touchedFinger.position.x - startPos.x) - comfortZone) + "px outside the comfort zone.");
					couldBeSwipe = false;  
				}
				break;
			case TouchPhase.Ended: //Swipe detection           
				if (couldBeSwipe)
				{             
					float swipeTime = Time.time - startTime;             
					Vector3 swipeDir = touchedFinger.position - startPos;
					float swipeDist = swipeDir.magnitude;  
					Vector3 swipeDirNormalized = swipeDir.normalized;
					
					Debug.Log("swipeDist : " + swipeDist + " and min swipe dis is : " + minSwipeDist);
					Debug.Log("swipeTime : " + swipeTime + " and max swipe time is : " + maxSwipeTime);
					
					if ((swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist)) 
					{
						//             // It's a swiiiiiiiiiiiipe!           
						float tolerance = 0.1f;
						float minSwipeDot = Mathf.Clamp01( 1.0f - tolerance );
						
//						switch(Input.deviceOrientation)
//						{
//						case DeviceOrientation.FaceDown:
//						case DeviceOrientation.FaceUp:
//						case DeviceOrientation.LandscapeLeft:
//						case DeviceOrientation.LandscapeRight:
//							m_HorizontalSwipeVector = Vector2.right;
//							m_VerticalSwipeVector = Vector2.up;
//							break;
//						case DeviceOrientation.Portrait:
//						case DeviceOrientation.PortraitUpsideDown:
//						case DeviceOrientation.Unknown:
//							m_HorizontalSwipeVector = Vector2.up;
//							m_VerticalSwipeVector = -Vector2.right;
//							break;
//						default:
//							break;
//						}

						m_HorizontalSwipeVector = Vector2.right;
						m_VerticalSwipeVector = Vector2.up;

						if( Vector2.Dot(swipeDirNormalized, m_HorizontalSwipeVector) >= minSwipeDot )
						{
							m_LastSwipe = InputHandler.eSwipeDirection.Right;
						}
						
						if( Vector2.Dot(swipeDirNormalized, -m_HorizontalSwipeVector) >= minSwipeDot )
						{
							m_LastSwipe = InputHandler.eSwipeDirection.Left;                  
						}
						
						if( Vector2.Dot(swipeDirNormalized, m_VerticalSwipeVector) >= minSwipeDot )
						{
							m_LastSwipe = InputHandler.eSwipeDirection.Up;                
						}
						
						if( Vector2.Dot(swipeDirNormalized, -m_VerticalSwipeVector) >= minSwipeDot )
						{
							m_LastSwipe = InputHandler.eSwipeDirection.Down;                  
						}
						
						Debug.Log("Last swipe : " + m_LastSwipe);

					}
				}
				break;
			default:
				break;
			}
		}
	}
}