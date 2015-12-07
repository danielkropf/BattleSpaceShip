using UnityEngine;
using System.Collections;

public class Casas_Events : MonoBehaviour {

	public string Team;
	private string[] xy = new string[2];
	private string[] firstXY = new string[2];
	public static bool clicked;
	private GameObject goToChange;
	private Btns_Functions btnsf;
	private Color32 oldColor;

	// Use this for initialization
	void Start () {
		btnsf = GameObject.Find("Main Camera").GetComponent<Btns_Functions>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		oldColor = this.GetComponent<SpriteRenderer>().color;
	}
	void OnMouseOver() {

		if (Team == "Ally")	this.GetComponent<SpriteRenderer>().color = new Color32(66, 66, 66, 255);
	}
	void OnMouseExit() {

		if (Team == "Ally") this.GetComponent<SpriteRenderer> ().color = oldColor;
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

				btnsf.usedPlaces[btnsf.spaceshipsPlaced, 0] = xy[0];
				btnsf.usedPlaces[btnsf.spaceshipsPlaced, 1] = xy[1];
				btnsf.spaceshipsPlaced++;
				oldColor = new Color32(255, 0, 0, 255);

				clicked = true;

			} else if(clicked) {

				firstXY[0] = btnsf.usedPlaces[0, 0];
				firstXY[1] = btnsf.usedPlaces[0, 1];
				xy = this.name.Split('-');
				Debug.Log(firstXY[0] + " " + firstXY[1] + " " + xy[0] + " " + xy[1]);

				if (btnsf.spaceshipsPlaced < 5 && (firstXY[0] != xy[0] || firstXY[1] != xy[1])) {
					Debug.Log("passou");

					//this.GetComponent<SpriteRenderer>().color = new Color32 (255, 0, 0, 255);
					
					switch (btnsf.spaceshipsPlaced) { 
						case 1:

							if (xy[0] != firstXY[0] && xy[1] == firstXY[1]) {

								if (int.Parse(xy[0]) < int.Parse(firstXY[0])) {
									goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
									goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

									goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
									goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

									if (int.Parse(xy[0]) > 1) {

										goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + xy[1]);
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
									}
								}
								if (int.Parse(xy[0]) > int.Parse(firstXY[0]))
								{
									goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
									goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

									goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
									goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

									if (int.Parse(xy[0]) < 5)
									{

										goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + xy[1]);
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
									}
								}

								oldColor = new Color32(255, 0, 0, 255);
								this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
								btnsf.spaceshipsPlaced++;
							}
							if (xy[1] != firstXY[1] && xy[0] == firstXY[0]) {

								if (int.Parse(xy[1]) < int.Parse(firstXY[1]))
								{
									goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
									goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

									goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) + 1).ToString());
									goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

									if (int.Parse(xy[1]) > 1)
									{

										goToChange = GameObject.Find(xy[0] + "-" + (int.Parse(xy[1]) - 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
									}
								}
								if (int.Parse(xy[1]) > int.Parse(firstXY[1]))
								{
									goToChange = GameObject.Find((int.Parse(xy[0]) + 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
									goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

									goToChange = GameObject.Find((int.Parse(xy[0]) - 1).ToString() + "-" + (int.Parse(xy[1]) - 1).ToString());
									goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

									if (int.Parse(xy[1]) < 5)
									{

										goToChange = GameObject.Find(xy[0] + "-" + (int.Parse(xy[1]) + 1).ToString());
										goToChange.GetComponent<SpriteRenderer>().color = new Color32(255, 216, 0, 255);
									}
								}

								oldColor = new Color32(255, 0, 0, 255);
								this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
								btnsf.spaceshipsPlaced++;
							}
	
							break;
						case 2:

							

							break;
						case 4:



							break;

					}
				}
			}
		}
	}
}
