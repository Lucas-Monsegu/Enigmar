using UnityEngine;
using System.IO;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


public class Save : MonoBehaviour {
    
	public void SaveGo(int lvl)
    {
        if (ReadGo() < lvl)
        {
            FileStream file = new FileStream(Application.persistentDataPath + "/Infs91.dat", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            data s = new data();
            s.lvlmax = lvl;
            bf.Serialize(file, s);
            file.Close();
        }
    }
    public int ReadGo()
    {
        if (File.Exists(Application.persistentDataPath + "/Infs91.dat"))
        {
            FileStream file = new FileStream(Application.persistentDataPath + "/Infs91.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            data s = bf.Deserialize(file) as data;
            
            file.Close();
        
            return s.lvlmax;
        }
        else
            return 0;

    }
    public void SaveHint(int hint)
    {
        short[] tab;
        if (File.Exists(Application.persistentDataPath + "/Infs91H.dat"))
        {
            FileStream file2 = new FileStream(Application.persistentDataPath + "/Infs91H.dat", FileMode.Open);
            BinaryFormatter bf2 = new BinaryFormatter();
            DataH s2 = bf2.Deserialize(file2) as DataH;
            tab = s2.tabhint;
            file2.Close();
        }
        else
        {
            tab = new short[32];
            Array.Clear(tab, 0, tab.Length);
        }
        FileStream file = new FileStream(Application.persistentDataPath + "/Infs91H.dat", FileMode.OpenOrCreate);
        BinaryFormatter bf = new BinaryFormatter();
        DataH s = new DataH();
        ++tab[hint];
        s.tabhint = tab;
        if (s.tabhint[hint] > 3)
            s.tabhint[hint] = 3;
        bf.Serialize(file, s);
        file.Close();
    }
    public int ReadAllHint()
    {
        if (File.Exists(Application.persistentDataPath + "/Infs91H.dat"))
        {

            FileStream file2 = new FileStream(Application.persistentDataPath + "/Infs91H.dat", FileMode.Open);
            BinaryFormatter bf2 = new BinaryFormatter();
            DataH s2 = bf2.Deserialize(file2) as DataH;
            file2.Close();
            int total = 0;
            foreach(short k in s2.tabhint)
            {
                total += k;
            }
            return total;
        }
        else
        {
            return 0;
        }
    }
    public short ReadHint(int lvl) {
        if (File.Exists(Application.persistentDataPath + "/Infs91H.dat"))
        {

            FileStream file2 = new FileStream(Application.persistentDataPath + "/Infs91H.dat", FileMode.Open);
            BinaryFormatter bf2 = new BinaryFormatter();
            DataH s2 = bf2.Deserialize(file2) as DataH;
            file2.Close();
            return s2.tabhint[lvl];
        }
        else
        {
            return 0;
        }
    }

    [Serializable]
    public class data
    {
        public int lvlmax;
    }
    [Serializable]
    public class DataH
    {
        public short[] tabhint;
    }

}
