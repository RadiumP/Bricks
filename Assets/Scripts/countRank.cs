using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countRank : MonoBehaviour
{

    public Text count;

    private string txtFile;
    // Use this for initialization
    void Start()
    {
        txtFile = Application.dataPath + "/Resources/count.txt";
        StreamReader sr = new StreamReader(txtFile);
        string line = sr.ReadLine();
        sr.Close();
        int num = Convert.ToInt32(line);
        count.text =  num.ToString();
      
    }

    // Update is called once per frame
    
}
