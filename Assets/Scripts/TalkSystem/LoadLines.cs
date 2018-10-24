using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Text;

public class LoadLines {

	public static string ReadXML(string fileName)
	{
		string filePath = Application.dataPath + "/Resources/RoleLines/" + fileName;
		if(!File.Exists(filePath))
		{
			Debug.LogError("Xml file (Role Lines) missing!");
			return "Role Lines Missing!";
		}
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(filePath);

		XmlNode node = xmlDoc.SelectSingleNode("lines");
		return node.InnerXml;
	}
}
