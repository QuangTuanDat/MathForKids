using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LearnController : MonoBehaviour {


    public void StartCountNumber()
    {
        SceneManager.LoadScene("CountNumber");
        Initiate.Fade("CountNumber", Color.black, 0.8f);
    }
    public void StartWriteNumber()
    {
        SceneManager.LoadScene("WriteNumber");
        Initiate.Fade("WriteNumber", Color.black, 0.8f);
    }

    public void StartRecognizeShape()
    {
        SceneManager.LoadScene("RecognizeShape");
        Initiate.Fade("RecognizeShape", Color.black, 0.8f);
    }

    public void StartDrawShape()
    {
        SceneManager.LoadScene("DrawShape");
        Initiate.Fade("RecognizeShape", Color.black, 0.8f);
    }

    public void StartRecognizeOperator()
    {
        SceneManager.LoadScene("RecognizeOperator");
        Initiate.Fade("RecognizeShape", Color.black, 0.8f);
    }

    public void StartDrawOperator()
    {
        SceneManager.LoadScene("DrawOperator");
        Initiate.Fade("RecognizeShape", Color.black, 0.8f);
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene("Menu");
        Initiate.Fade("RecognizeShape", Color.black, 0.8f);
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
