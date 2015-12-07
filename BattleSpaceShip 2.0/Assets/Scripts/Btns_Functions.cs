using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Btns_Functions : MonoBehaviour {

	public string userID;
	public string password;

	public Text txtUser;
	public Text txtPassword;

	public void login() {

		userID = txtUser.text;
		password = txtPassword.text;
	}
	public void changeColor(GameObject toChange) {

		toChange.GetComponent<SpriteRenderer> ().color = new Color (0.86f, 0.86f, 0.86f, 0);
		Debug.Log ("rola");
	}

}
