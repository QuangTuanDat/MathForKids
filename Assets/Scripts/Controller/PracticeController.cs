using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PracticeController : MonoBehaviour {

    public void StartSetQuestion()
    {
        SceneManager.LoadScene("SetQuestion");
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene("Menu");
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
