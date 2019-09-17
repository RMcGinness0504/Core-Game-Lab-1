using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoad
{
	public static void Save(Data dt)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/notPokemon.gd");
		bf.Serialize(file, dt);
		file.Close();
	}

	public static Data Load()
	{
		if (File.Exists(Application.persistentDataPath + "/notPokemon.gd"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/notPokemon.gd", FileMode.Open);
			Data dt = (Data)bf.Deserialize(file);
			file.Close();
            return dt;
		}
        else
        {
            return new Data(new int[24], new int[24], new int[24]);
        }
	}
}