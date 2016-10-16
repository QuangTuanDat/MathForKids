using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SetQuestionControler : MonoBehaviour {

    public void PreviousScene()
    {
        SceneManager.LoadScene("Practice");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
