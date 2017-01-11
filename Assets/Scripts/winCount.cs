using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winCount : MonoBehaviour {

    public Text count;

    private string txtFile;
	// Use this for initialization
	void Start () {
        txtFile = Application.dataPath + "/Resources/count.txt";
        StreamReader sr = new StreamReader(txtFile);
        string line = sr.ReadLine();
        sr.Close();
        int num = Convert.ToInt32(line) + 1;
        count.text = "NO." + num.ToString();
        StreamWriter sw = new StreamWriter(txtFile);
        sw.Write(num.ToString());
        sw.Close();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
