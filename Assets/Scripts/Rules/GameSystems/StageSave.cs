using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class StageData
{
    public int stageClear;
}
public class StageSave : MonoBehaviour
{
    public static StageSave instance;
    public StageData stageData = new();

    private string path;
    private string fileName = "/save";

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        path = Application.persistentDataPath + fileName;
        Debug.Log(path);  //경로표시

        LoadData();
    }

    public void SaveData() //저장함수 
    {
        string data = JsonUtility.ToJson(stageData);  //데이타를 문자열로 저장

        File.WriteAllText(path, data);  //File. 사용하려면 System.IO 필요함
    }

    public void LoadData() //불러오기 함수
    {
        if (!File.Exists(path))
        {
            SaveData();
        }

        string data = File.ReadAllText(path);

        stageData = JsonUtility.FromJson<StageData>(data);
    }

    public void ClearedStage() //데이타 변경해주는 함수 
    {
        stageData.stageClear += 1;
    }
}
