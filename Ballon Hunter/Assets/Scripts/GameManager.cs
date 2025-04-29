using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[Serializable]
class PlayerData
{
    [Header("ProgressoAtual")]
    public int FaseAtual;
}



public class GameManager : MonoBehaviour
{
    public string[] nomesDasFases = { "Fase 1", "Fase 2", "Fase 6", "Fase 10", "Fase 12" };
    public int FaseAtual;
    public static GameManager GM;
    private string filePath;
    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }


        filePath = Application.persistentDataPath + "BallonHunter.dat";

        DontDestroyOnLoad(gameObject);


    }
    // Start is called before the first frame update
    void Start()
    {

        if (File.Exists(filePath))
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);

            PlayerData data = (PlayerData)BF.Deserialize(file);
            file.Close();


            FaseAtual = data.FaseAtual;



        }



    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);

        PlayerData data = new PlayerData();

        data.FaseAtual = FaseAtual;
        bf.Serialize(file, data);
        file.Close();
    }


}

    
