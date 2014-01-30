using UnityEngine;
using System.Collections;

public class GuiPosition : MonoBehaviour {

	//variables for poistioning of guielements
	private float rx;
	private float ry;
	private float curWidth;
	private float curHeight;
	private Vector2 btnTexPos;
	private Vector2 btnTexSiz;
	private GUITexture currTex;

	// Use this for initialization
	void Start () {
		currTex = GetComponent<GUITexture>();
		Screen.SetResolution(1280, 720, true);
		curWidth = Screen.width;
		curHeight = Screen.height;
		rx = curWidth/1280;
		ry = curHeight/720;
		btnTexPos = new Vector2(GetComponent<GUITexture>().pixelInset.x,GetComponent<GUITexture>().pixelInset.y);
		currTex.pixelInset= new Rect(btnTexPos.x*rx,btnTexPos.y*ry,128*rx,72*ry);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
