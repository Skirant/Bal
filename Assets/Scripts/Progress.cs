using System.Linq;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlayerInfo
{
    public int _coin;
    public int _numberOfLevel;
    public bool[] _saleBackground;
    public bool[] _saleBall;
    public int _curectBackground;
}

public class Progress : MonoBehaviour
{
    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")]
    private static extern void SaveYG(string date);
    [DllImport("__Internal")]
    public static extern void LoadYG();


    public static Progress Instance;

    private List<KeyCode> keySequence = new List<KeyCode>();
    private KeyCode[] desiredSequence = new KeyCode[] { KeyCode.Alpha2, KeyCode.Alpha2, KeyCode.Alpha8, KeyCode.Alpha8 };

    private void Awake()
    {
        PlayerInfo._saleBall = new bool[9];
        PlayerInfo._saleBackground = new bool[9];

        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
#if !UNITY_EDITOR && UNITY_WEBGL
            LoadYG();
#endif
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Cheat();
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);

#if !UNITY_EDITOR && UNITY_WEBGL
        SaveYG(jsonString);
#endif
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        //_playerInfoText.text = PlayerInfo.Coins + "\n" + PlayerInfo.Weight + "\n" + PlayerInfo.Level + "\n" + PlayerInfo.HealthBarrier + "\n" + PlayerInfo.CorrenctLevel; 
    }

    public void Cheat()
    {
        // ���������� ��� ��������� �������
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            // ���� �����-�� ������� ���� ������
            if (Input.GetKeyDown(key))
            {
                // ��������� �� � ������ ������� ������
                keySequence.Add(key);

                // ���� ������ ������� ������ ���� ������� �������� ������������������
                if (keySequence.Count > desiredSequence.Length)
                {
                    // ������� ������ ������� �� ������
                    keySequence.RemoveAt(0);
                }

                // ���� ������ ������� ������ ��������� � �������� �������������������
                if (Enumerable.SequenceEqual(keySequence, desiredSequence))
                {
                    // ��������� 1000 � _coin
                    PlayerInfo._coin += 1000;

                    // ������� ������ ������� ������
                    keySequence.Clear();
                }
            }
        }
    }
}
