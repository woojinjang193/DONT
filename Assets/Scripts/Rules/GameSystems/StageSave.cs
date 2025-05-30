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
        Debug.Log(path);  //���ǥ��

        LoadData();
    }

    public void SaveData() //�����Լ� 
    {
        string data = JsonUtility.ToJson(stageData);  //����Ÿ�� ���ڿ��� ����

        File.WriteAllText(path, data);  //File. ����Ϸ��� System.IO �ʿ���
    }

    public void LoadData() //�ҷ����� �Լ�
    {
        if (!File.Exists(path))
        {
            SaveData();
        }

        string data = File.ReadAllText(path);

        stageData = JsonUtility.FromJson<StageData>(data);
    }

    public void ClearedStage() //����Ÿ �������ִ� �Լ� 
    {
        stageData.stageClear += 1;
    }
}
