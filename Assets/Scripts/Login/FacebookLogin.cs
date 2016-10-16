using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FacebookLogin : MonoBehaviour
{

    //public GameObject DialogLoggedIn;
    //public GameObject DialogLoggedOut;
    public GameObject DialogUserName;
    public GameObject DialogImageProfile;
    public GameObject DialogButtonLogin;

    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
        DialogImageProfile.SetActive(false);
    }


    void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            Debug.Log("FB is init");
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
        DealWithFBMenus(FB.IsLoggedIn);
    }

    void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void FBLogin()
    {
        //List<string> perms = new List<string>();
        //perms.Add("pubic_profile", "email");
        //FB.LogInWithPublishPermissions(perms, AuthCallback);
        FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" }, AuthCallback);
    }

    public void IgnoreLogin()
    {
        StartCoroutine(LoadStartScene(0.3f));
        Initiate.Fade("Menu", Color.black, 0.8f);
    }
    void AuthCallback(ILoginResult result)
    {

        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
            DealWithFBMenus(FB.IsLoggedIn);
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    void DealWithFBMenus(bool isLoggedIn)
    {
        if (isLoggedIn)
        {
            //DialogLoggedIn.SetActive(true);
            //DialogLoggedOut.SetActive(false);
            DialogButtonLogin.SetActive(true);
            DialogImageProfile.SetActive(true);
            FB.API("/me?fields=name", HttpMethod.GET, DisplayUserName);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayImageProfile);
            StartCoroutine(LoadStartScene(1.5f));

        }
        else
        {
            //DialogLoggedIn.SetActive(false);
            //DialogLoggedOut.SetActive(true);
            DialogImageProfile.SetActive(false);

        }
    }
    IEnumerator LoadStartScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Menu");
    }

    void DisplayUserName(IResult result)
    {
        Text UserName = DialogUserName.GetComponent<Text>();
        if (result.Error == null)
        {
            UserName.text = "Chào bạn, " + result.ResultDictionary["name"];
        }
        else
        {
            Debug.Log(result.Error);
        }
    }

    void DisplayImageProfile(IGraphResult result)
    {
        if (result.Texture != null)
        {
            Image imageProfile = DialogImageProfile.GetComponent<Image>();
            imageProfile.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
        }
    }


}

