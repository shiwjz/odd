using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelupButton : MonoBehaviour
{
    public string fileName = "PlayerDB";

    private void Start()
    {
        TextAsset csvFile = Resources.Load(fileName) as TextAsset;
        if(csvFile != null)
        {
            string fileContent = csvFile.text;
            Debug.Log(fileContent);

            string[] lines = fileContent.Split('\n');
            foreach(string line in lines)
            {
                Debug.Log(line);
                string[] values = line.Split(',');
                foreach(string value in values)
                {
                    Debug.Log(value);
                }
            }
        }
    }
}
