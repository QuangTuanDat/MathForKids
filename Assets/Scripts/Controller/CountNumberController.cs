using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountNumberController : MonoBehaviour
{
    public GameObject btnRight;
    public GameObject btnLeft;
    public Image imgUnit;
    public Image imgDozen;
    public Image imgHundred;
    AudioClip sound;
    int number = 1;
    string filePathUnit = "", filePathDozen = "", filePathHundred = "";
    string filePathSound = "";
    string hangTram, hangChuc, hangDonVi;

    void Start()
    {
        LoadImage();
        LoadSound();
        DocSo();
        PreviousNumber();
        NextNumber();
    }

    public void LoadImage()
    {
        TachSo();
        imgUnit.sprite = Resources.Load<Sprite>(filePathUnit);
        imgDozen.sprite = Resources.Load<Sprite>(filePathDozen);
        imgHundred.sprite = Resources.Load<Sprite>(filePathHundred);

        int a = Screen.width;
        int b = Screen.height;
        if (imgUnit.enabled == true)
        {
            imgUnit.transform.localPosition = new Vector2(a / 107, b / 4);
        }
        if (imgUnit.enabled == true && imgDozen.enabled == true)
        {
            imgUnit.transform.localPosition = new Vector2(a / 107 + 100, b / 4);
            imgDozen.transform.localPosition = new Vector2(-a / 30, b / 4);
        }
        if (imgUnit.enabled == true && imgDozen.enabled == true && imgHundred.enabled == true)
        {
            imgUnit.transform.localPosition = new Vector2(a / 107 + 125, b / 4);
            imgDozen.transform.localPosition = new Vector2(-a / 30 + 25, b / 4);
            imgHundred.transform.localPosition = new Vector2(-a / 9, b / 4);
        }
    }

    public void GetPath(string DonVi, string Chuc, string Tram)
    {
        filePathUnit = "Numbers/CountNumber/n" + DonVi;
        filePathDozen = "Numbers/CountNumber/n" + Chuc;
        filePathHundred = "Numbers/CountNumber/n" + Tram;
    }
    public void TachSo()
    {
        string stringNumber = number.ToString();

        if (stringNumber.Length == 1)
        {
            hangDonVi = stringNumber.Substring(stringNumber.Length - 1, 1);
            imgUnit.enabled = true;
            imgDozen.enabled = false;
            imgHundred.enabled = false;
        }

        if (stringNumber.Length == 2)
        {
            hangDonVi = stringNumber.Substring(stringNumber.Length - 1, 1);
            hangChuc = stringNumber.Substring(stringNumber.Length - 2, 1);
            imgUnit.enabled = true;
            imgDozen.enabled = true;
            imgHundred.enabled = false;
        }

        if (stringNumber.Length == 3)
        {
            hangDonVi = stringNumber.Substring(stringNumber.Length - 1, 1);
            hangChuc = stringNumber.Substring(stringNumber.Length - 2, 1);
            hangTram = stringNumber.Substring(stringNumber.Length - 3, 1);
            imgUnit.enabled = true;
            imgDozen.enabled = true;
            imgHundred.enabled = true;
        }

        GetPath(hangDonVi, hangChuc, hangTram);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene("Learn");
    }
    public void PreviousNumber()
    {
        if (number > 0)
            number--;
        if (number != 120)
            btnRight.SetActive(true);
        if (number != 0)
            btnLeft.SetActive(true);
        else
            btnLeft.SetActive(false);
        LoadImage();
        DocSo();
        LoadSound();
    }
    public void NextNumber()
    {
        if (number < 120)
            number++;
        if (number != 0)
            btnLeft.SetActive(true);
        if (number != 120)
            btnRight.SetActive(true);
        else
            btnRight.SetActive(false);
        LoadImage();
        DocSo();
        LoadSound();

    }

    public void LoadSound()
    {
        filePathSound = "Sounds/Numbers/" + number;
        sound = Resources.Load(filePathSound) as AudioClip;
        GameObject obj = new GameObject("Number Sound");
        obj.AddComponent<AudioSource>();
        obj.GetComponent<AudioSource>().clip = sound;
        obj.GetComponent<AudioSource>().Play();
    }

    void Update()
    {

    }
    public void DocSo()
    {
        int i;
        string ketQua = "";
        string stringNumber = number.ToString();
        int[] A = new int[stringNumber.Length + 1];
        for (i = stringNumber.Length; i > 0; i--)
        {
            A[i] = int.Parse(stringNumber.Substring(stringNumber.Length - i, 1));
            ketQua += ChuyenSoSangChu(i, A[i], stringNumber) + Hang(i, A[i], stringNumber);
        }
        Debug.Log("So duoc chuyen thanh chu: " + ketQua);
    }

    public string ChuyenSoSangChu(int i, int x, string n)
    {

        string s = "";
        switch (x)
        {
            case 0:
                if (i % 3 == 0 && (n.Substring(n.Length - i + 1, 2) != "00"))
                    s = "khong ";
                else s = "";
                break;
            case 1:
                if (i % 3 == 2)
                    s = "";
                else
                    s = "mot ";
                break;
            case 2:
                s = "hai ";
                break;
            case 3:
                s = "ba ";
                break;
            case 4:
                s = "bon ";
                break;
            case 5:
                if (n.Length != i && i % 3 == 1 && n.Substring(n.Length - i - 1, 1) != "0")
                    s = "lam ";
                else
                    s = "nam ";
                break;
            case 6:
                s = "sau ";
                break;
            case 7:
                s = "bay ";
                break;
            case 8:
                s = "tam ";
                break;
            case 9:
                s = "chin ";
                break;
        }
        return s;
    }
    static string Hang(int i, int x, string n)
    {
        string s = "";
        int t = i % 3;
        switch (t)
        {
            case 0:
                if (n.Substring(n.Length - i, 3) != "000")
                    s = "tram ";
                else s = "";
                break;
            case 2:
                if (x == 0 && n.Substring(n.Length - i + 1, 1) != "0")
                    s = "linh ";
                else
                    if (n.Substring(n.Length - i, 2) == "00")
                    s = "";
                else
                    s = "muoi ";
                break;
        }
        return s;
    }
}
