using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.UI;
using Assets;
using System.IO;
using UnityEngine.EventSystems;

public class AddOperatorController : MonoBehaviour {

    public Text txtQuestion;

    ArrayList arr = new ArrayList();
    ConnectDB con;
    List<Question> question = new List<Question>();
    Texture2D imgFish;
    string filePathNumber = "";
    int size = Screen.width / 11;

    void Start()
    {
        getQuestion();
        init();
        GetFilePath();
    }
    public void GetFilePath()
    {
        int i = Random.Range(1, 8);
        filePathNumber = "Items/icon" + 1;
        imgFish = Resources.Load(filePathNumber) as Texture2D;
    }

    void OnGUI()
    {
        for (int i = 0; i < question[0].SecondNumber; i++)
        {
            GUI.DrawTexture(new Rect(i * size + Screen.width / 2 + 10, Screen.height / 2 - size, size, size), imgFish);
        }
        for (int i = 1; i <= question[0].FisrtNumber; i++)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - i * size - 15, Screen.height / 2 - size, size, size), imgFish);
        }
    }
    
    public void getQuestion()
    {
        con = new ConnectDB();
        con.Open();
        string sqlQuery = "SELECT * FROM questions";
        IDataReader reader;
        reader = con.getData(sqlQuery);
        while (reader.Read())
        {
            Question qs = new Question();
            qs.Id = reader.GetInt32(0);
            qs.FisrtNumber = reader.GetInt32(1);
            qs.SecondNumber = reader.GetInt32(2);
            qs.RightAnswer = reader.GetInt32(3);
            qs.WrongAnswer1 = reader.GetInt32(4);
            qs.WrongAnswer2 = reader.GetInt32(5);
            qs.WrongAnswer3 = reader.GetInt32(6);
            qs.Level = reader.GetInt32(7);
            qs.Priority = reader.GetInt32(8);
            question.Add(qs);
        }
        reader.Close();
        reader = null;
    }

    public void getTextOfButton()
    {
       
        string answer = "";
        string rightAnswer = "" + question[0].RightAnswer;
        answer = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
       // Debug.Log("ket qua lay duoc cua button la:" + answer);
        if (answer.Equals(rightAnswer))
        {
            Debug.Log("Ban da tra loi dung roi");
        }
        else
        {
            Debug.Log("Ban da tra loi sai roi");
        }
            
        question.RemoveAt(0);
        if (question.Count <= 0)
        {
            Debug.Log("Ban da hoan thanh bo cau hoi!");
            return;
        }
        init();
    }

    public void init()
    {
        txtQuestion = GameObject.Find("txtQuestion").GetComponent<Text>();

        txtQuestion.text = question[0].FisrtNumber + " + " + question[0].SecondNumber + " bằng bao nhiêu?";
        GameObject.Find("btnAnswer1").GetComponentInChildren<Text>().text = "" + question[0].RightAnswer;
        GameObject.Find("btnAnswer2").GetComponentInChildren<Text>().text = "" + question[0].WrongAnswer1;
        GameObject.Find("btnAnswer3").GetComponentInChildren<Text>().text = "" + question[0].WrongAnswer2;
        GameObject.Find("btnAnswer4").GetComponentInChildren<Text>().text = "" + question[0].WrongAnswer3;
    }
    //public void onclick1()
    //{
    //    string rightAnswer = "" + question[0].RightAnswer;
    //    //string answer = btnAnswer1.GetComponentInChildren<Text>().text;
    //    if (answer.Equals(rightAnswer))
    //    {
    //        Debug.Log("Dung roi");
    //    }
    //    else
    //    {
    //        Debug.Log("Sai roi");
    //    }
    //    question.RemoveAt(0);
    //    if (question.Count <= 0)
    //    {
    //        Debug.Log("ban da hoan thanh!");
    //        return;
    //    }
    //    init();

    //}

    
}
