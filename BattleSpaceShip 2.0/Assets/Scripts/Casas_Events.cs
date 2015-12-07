using UnityEngine;
using System.Collections;

public class Casas_Events : MonoBehaviour {

	public string Team;
	private string[] xy = new string[2];
	public static bool clicked;
	private GameObject goToChange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {

		if (Team == "Ally" && !clicked) this.GetComponent<SpriteRenderer> ().color = new Color32 (66, 66, 66, 255);
	}
	void OnMouseExit() {

		if (Team == "Ally" && !clicked) this.GetComponent<SpriteRenderer> ().color = new Color32 (255, 255, 255, 255);
	}
	void OnMouseDown() {

		if (Team == "Ally") {
			if(!clicked) {

				this.GetComponent<SpriteRenderer>().color = new Color32 (255, 0, 0, 255);
				xy = this.name.Split('-');

				int xy2;

				xy2 = int.Parse(xy[1]);
				if(xy2 < 5) {
					goToChange = GameObject.Find(xy[0] + "-" + (xy2 + 1).ToString());
					goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
				}
				xy2 = int.Parse(xy[1]);
				if(xy2 > 1) {
					goToChange = GameObject.Find(xy[0] + "-" + (xy2 - 1).ToString());
					goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
				}
				xy2 = int.Parse(xy[0]);
				if(xy2 < 5) {
					goToChange = GameObject.Find((xy2 + 1).ToString() + "-" + xy[1]);
					goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
				}
				xy2 = int.Parse(xy[0]);
				if(xy2 > 1) {
					goToChange = GameObject.Find((xy2 - 1).ToString() + "-" + xy[1]);
					goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
				}

				clicked = true;

			} else if(clicked) {

				this.GetComponent<SpriteRenderer>().color = new Color32 (255, 0, 0, 255);
				xy = this.name.Split('-');
			}
		}
	}
}
