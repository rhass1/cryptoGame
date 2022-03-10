using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class GCom : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void gCom(string data);

    private static GCom instance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GCom();
            }

            return _instance;
        }
    }

    private static GCom _instance { get; set; }
    
    private string UUID { get; set; }

    private GCom()
    {
        this.UUID = Guid.NewGuid().ToString();
    }

    public static void StartGame()
    {
        instance.SendGCom("start");
    }

    public static void EndGame()
    {
        instance.SendGCom("end");
    }

    public static void PauseGame()
    {
        instance.SendGCom("pause");
    }

    public static void ResumeGame()
    {
        instance.SendGCom("resume");
    }

    private void SendGCom(string action)
    {
        long timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();

        string json = JsonConvert.SerializeObject(new
        {
            action,
            timestamp,
            uuid = this.UUID
        });

        string data = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

        gCom(scramble(data));
    }

    private static string scramble(string input)
    {
        StringBuilder output = new StringBuilder();
        System.Random n = new System.Random();

        foreach (char c in input)
        {
            output.Append(c);

            output.Append((char)n.Next(32, 126));
        }

        return output.ToString();
    }
}
