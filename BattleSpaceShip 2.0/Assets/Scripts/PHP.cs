using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PHP : MonoBehaviour {
	
	public string url = "danielkropf.16mb.com/BattleSpaceShip.php";
	private Btns_Functions btnsf;
	
	// Use this for initialization
	void Start () {
		btnsf = this.gameObject.GetComponent<Btns_Functions> ();
	}
	
	IEnumerator SaveToPHP()
	{
		WWWForm form = new WWWForm();
		form.AddField("Service", "Save");
		form.AddField("UserID", 1);
		form.AddField("Senha", 1);
		
		WWW w = new WWW(url, form);
		yield return w;
		Debug.Log(w.text);
	}
	
	IEnumerator LoadFromPHP()
	{
		WWWForm form = new WWWForm();
		form.AddField("Service", "Load");
		form.AddField ("UserID", "jamal");
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
				case "Senha":
					//tw.tst.lvlPlayer = int.Parse(info[1]);
					Debug.Log(info[1]);
					break;
					
				}
			}
		}
	}
	
	public void Save()
	{
		/*if(tw.su.Nick != "")*/ StartCoroutine (SaveToPHP ());
	}
	
	public void Load()
	{
		/*if(tw.su.Nick != "")*/ StartCoroutine (LoadFromPHP ());
	}
}
