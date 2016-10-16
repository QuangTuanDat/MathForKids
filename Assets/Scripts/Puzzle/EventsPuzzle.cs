using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

///Implement your game events in this script
public class EventsPuzzle : MonoBehaviour
{
    //Load scene1
    public void LoadPicturesWorld(Object ob)
    {
        SceneManager.LoadScene("Scene1");
    }

    //Load scene2
    public void LoadWordsWorld(Object ob)
    {
        SceneManager.LoadScene("Scene1");
    }

    //Load Home scene
    public void LoadHome(Object ob)
    {
        SceneManager.LoadScene("Home");
    }

    //Quit the app
    public void QuitApplication(Object ob)
    {
        Application.Quit();
    }
}