using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {

    private int defWidth;
    private int defHeight;
    public void StartProgram()
    {
        Application.LoadLevel("Menu");
    }

	// Use this for initialization
	void Start () {
        Screen.fullScreen = !Screen.fullScreen;

    }
	
	// Update is called once per frame
	void Update () {
        Screen.fullScreen = !Screen.fullScreen;
    }

}
