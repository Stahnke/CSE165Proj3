using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class XYZParser : MonoBehaviour {

    public GameObject[] prefabs;

    private List<Vector3> positions = new List<Vector3>();

    private void Start()
    {
        Parse("Sample-track.txt");
    }

    public void Parse(string filename)
    {
        //Begin loading process
        print("Parsing Data");

        //Set up path
        string path = Application.dataPath + "/Resources/Files/" + filename;

        string line;
        float xpos, ypos, zpos;

        //Open file
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        int i = 0;
        //Read file
        while((line = file.ReadLine()) != null)
        {
            if(line != "\n" && line != "")
            {
                //READ FROM FILE
                List<float> numbers = new List<float>(Array.ConvertAll(line.Split(' '), float.Parse));

                //Set x y z
                xpos = numbers[0];
                ypos = numbers[1];
                zpos = numbers[2];

                //Store vector into our vector3 list
                positions.Add(new Vector3(xpos, ypos, zpos));
                print(positions[i].x + " " + positions[i].y + " " + positions[i].z + " ");
                i++;
            }
        }
        file.Close();
    }
}
