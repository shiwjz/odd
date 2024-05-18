/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelupButton : MonoBehaviour
{
    public string fileName = "PlayerDB";
    public int lv;
    public int price;
    public int production_p;
    public int i, j;
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

        for(i=0; i<1000; i++)
        {

            string lv = value[0];



        }
    }
}
*/