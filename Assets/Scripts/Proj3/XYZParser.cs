using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class XYZParser : MonoBehaviour {

    public float scaleFactor = 1.0f;

    public List<Vector3> Parse(string filename)
    {
        //Begin loading process
        print("Parsing Data");
    
        List<Vector3> positions = new List<Vector3>();

        //Set up path
        string path = Application.dataPath + "/Resources/Files/" + filename;

        string line;
        float xpos, ypos, zpos;

        //Open file
        System.IO.StreamReader file = new System.IO.StreamReader(path);

        //Read file
        while((line = file.ReadLine()) != null)
        {
            if(line != "\n" && line != "")
            {
                //READ FROM FILE
                List<float> numbers = new List<float>(Array.ConvertAll(line.Split(' '), float.Parse));

                //Set x y z
                xpos = numbers[0] * scaleFactor;
                ypos = numbers[1] * scaleFactor;
                zpos = numbers[2] * scaleFactor;

                //Store vector into our vector3 list
                positions.Add(new Vector3(xpos, ypos, zpos));
            }
        }
        file.Close();

        return positions;
    }
}
