using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SavePHP : MonoBehaviour {
	
	public string url = "danielkropf.16mb.com";
	
	// Use this for initialization
	void Start () {

	}
	
	IEnumerator SaveToPHP()
	{
		WWWForm form = new WWWForm();
		form.AddField("Service", "Save");
		form.AddField("UserID", tw.su.Nick);
		form.AddField("Senha", tw.tst.lvlPlayer);
		
		WWW w = new WWW(url, form);
		yield return w;
		Debug.Log(w.text);
	}
	
	IEnumerator LoadFromPHP()
	{
		WWWForm form = new WWWForm();
		form.AddField("Service", "Load");
		form.AddField ("UserID", tw.su.Nick);
		WWW w = new WWW(url, form);
		yield return w;
		Debug.Log(w.text);
		if (w.text == "error") {
			//USUARIO NAO EXISTE
			Debug.Log ("NAO ECZISTE!");
		} else
		{
			string[] datas = w.text.Split(';');
			foreach(string data in datas)
			{
				string[] info = data.Split('=');
				switch(info[0])
				{
				case "XP":
					sld.value = int.Parse(info[1]);
					break;
				case "Senha":
					tw.tst.lvlPlayer = int.Parse(info[1]);
					break;

				}
			}
		}
	}
	
	public void Save()
	{
		if(tw.su.Nick != "") StartCoroutine (SaveToPHP ());
	}
	
	public void Load()
	{
		if(tw.su.Nick != "") StartCoroutine (LoadFromPHP ());
	}
}