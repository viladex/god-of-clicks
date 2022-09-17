using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Game : MonoBehaviour
{
    [SerializeField] int Score;
    public int[] CostInt;
    private int ClickScore = 1;

    public Text[] CostText;
    public Text ScoreText;

    private Save sv = new Save();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
            Score = sv.Score;
            ClickScore = sv.ClickScore;

            for (int i = 0; i < 0; i++)
            {
                CostInt[i] = sv.CostInt[i];
                CostText[i].text = sv.CostInt[i] + "$";
            }
        }
    }

    public void Repeat()
    {
        Score = 0;
    }

    public void OnClickButton()
    {
        Score+= ClickScore;
    }

    private void Update()
    {
        ScoreText.text = Score + "$";
    }
    public void Exit()
    {
        Application.Quit();
        print('A');
    }

    public void LoadScene(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    public void ShopSaved()
    {
        SceneManager.LoadScene(3);
    }

    public void OnClickBuyLevl1()
    {
        if (Score >= CostInt[0])
        {
            Score -= CostInt[0];
            CostInt[0] *= 2;
            ClickScore *= 2;
            CostText[0].text = CostInt[0] + "$";
        }
    }

    private void OnApplicationQuit()
    {
        sv.Score = Score;
        sv.ClickScore = ClickScore;
        sv.CostInt = new int[2];

        for (int i = 0; i < 0; i++)
        {
            sv.CostInt[i] = CostInt[i];
        }

        PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
    }

}

[Serializable]
public class Save
{
    public int Score;
    public int ClickScore;
    public int[] CostInt;

}
