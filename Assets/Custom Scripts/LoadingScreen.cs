using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	public string levelToLoad;
	public GameObject loadText;
	public GameObject loadProgressBar;


	private GUILayer layer;
	private int loadProgress = 0;
	// Use this for initialization
	void Start () {
		loadText.SetActive(false);
		loadProgressBar.SetActive(false);
		layer = Camera.main.GetComponent<GUILayer>();
	}
	
	// Update is called once per frame
	void Update () {

		handleTouchGestureInput();
	
	}

	void handleTouchGestureInput()
	{
		if(Input.touches.Length > 0)
		{
			for(int i=0; i< Input.touches.Length; i++)
			{
//				if(layer.HitTest(Input.GetTouch(i).position)) 
//				{
					if(Input.GetTouch(i).phase == TouchPhase.Ended)
					{
						StartCoroutine(displayLoadLevel());
//						loadText.SetActive(false);
//						loadProgressBar.SetActive(false);
						//Application.LoadLevel(levelToLoad);
					}
//				}
			}
		}
	}

	IEnumerator displayLoadLevel()
	{
		loadText.SetActive(true);
		loadProgressBar.SetActive(true);

		loadProgressBar.transform.localScale = new Vector3(loadProgress,loadProgressBar.transform.localScale.y, loadProgressBar.transform.localScale.z);
		loadText.guiText.text = "Loading " + loadProgress + "%";

		AsyncOperation async = Application.LoadLevelAsync(levelToLoad);

		while(!async.isDone)
		{
			loadProgress = (int)(async.progress * 100);
			loadProgressBar.transform.localScale = new Vector3(async.progress*2,loadProgressBar.transform.localScale.y, loadProgressBar.transform.localScale.z);
			loadText.guiText.text = "Loading " + loadProgress + "%";
			yield return null;
		}


	}
}
