﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour {

    public bool start = false;
    public float fadeDamp = 0.5f;
    public string fadeScene;
    public float alpha = 0.0f;
    public Color fadeColor;
    public bool isFadeIn = false;
    void Start()
    {

    }

    // Update is called once per frame
    void OnGUI()
    {
        //if (!start)
        //{
        //    return;
        //}
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        Texture2D myTex;
        myTex = new Texture2D(1, 1);
        myTex.SetPixel(0, 0, fadeColor);
        myTex.Apply();
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), myTex);
        if (isFadeIn)
            alpha = Mathf.Lerp(alpha, -0.1f, fadeDamp * Time.deltaTime);
        else
            alpha = Mathf.Lerp(alpha, 1.1f, fadeDamp * Time.deltaTime);

        if (alpha >= 1 && !isFadeIn)
        {
            SceneManager.LoadScene(fadeScene);
            DontDestroyOnLoad(gameObject);
        }
        else if (alpha <= 0 && isFadeIn)
        {
            Destroy(gameObject);
        }
    }

    void LevelWasLoaded(int level)
    {
        isFadeIn = true;
    }
}
