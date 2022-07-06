using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillText : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] TMP_Text _Text;

    void Start()
    {
        Att();
    }

    public void Att()
    {
        PlayerPrefs.GetInt("vitimas");
        gameData.Kills = PlayerPrefs.GetInt("vitimas");
        TextUpdate();
    }

    public void KillCount()
    {
        PlayerPrefs.GetInt("vitimas");
        gameData.Kills += 1;
        TextUpdate();
    }

    private void TextUpdate()
    {
        _Text.text = "Kills: " + gameData.Kills.ToString();
    }

    public void SaveKills()
    {
        PlayerPrefs.SetInt("vitimas", gameData.Kills);
    }
}
