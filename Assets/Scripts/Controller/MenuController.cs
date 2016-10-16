using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    AudioClip backgroundMusic;
    string filePathMusic = "";
    void Start()
    {
        GetFilePath();
        LoadSound();
    }
    
    public void StartLearn()
    {
        SceneManager.LoadScene("Learn");
        Initiate.Fade("Learn", Color.black, 0.8f);
    }
    public void StartPratice()
    {
        SceneManager.LoadScene("Practice");
        Initiate.Fade("Practice", Color.black, 0.8f);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene("Start");
        Initiate.Fade("Start", Color.black, 0.8f);
    }

    public void GetFilePath()
    {
        filePathMusic = "Sounds/Backgrounds/Menu" ;
    }
    public void LoadSound()
    {
        backgroundMusic = Resources.Load(filePathMusic) as AudioClip;
        GameObject obj = new GameObject("Menu Music");
        obj.AddComponent<AudioSource>();
        obj.GetComponent<AudioSource>().clip = backgroundMusic;
        obj.GetComponent<AudioSource>().Play();
    }
    void Update () {
	
	}
}
