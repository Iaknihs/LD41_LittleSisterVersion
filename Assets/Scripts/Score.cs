using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public double gems;
	public float shovelMult;
	public float pickMult;
	public float drillMult;
	public float tntMult;
	public float strangeMult;
	public float magicMult;
	public float cookieMult;
	public float ancientMult;
	public float heartMult;

	public Text text;
	public Image shovel;
	public Image pick;
	public Image drill;
	public Image tnt;
	public Image strange;
	public Image magic;
	public Image cookie;
	public Image ancient;
	public Image heart;

	private LinkedList<int> collected;

	// Use this for initialization
	void Start () {
		collected = new LinkedList<int>();
	}
	
	// Update is called once per frame
	void Update () {
		gems += ((collected.Count==0?0.0:0.05)
			*(collected.Contains(35)?shovelMult:1.0)
			*(collected.Contains(40)?pickMult:1.0)
			*(collected.Contains(45)?tntMult:1.0)
			*(collected.Contains(33)?strangeMult:1.0)
			*(collected.Contains(15)?magicMult:1.0)
			*(collected.Contains(17)?cookieMult:1.0)
			*(collected.Contains(150)?ancientMult:1.0)
			*(collected.Contains(8)?heartMult:1.0)
			*(collected.Contains(99)?drillMult:1.0))
			* Time.deltaTime;

		if (gems < 10)
			text.text = System.Convert.ToString (((float)((int)(gems * 10))) / 10);
		else
			text.text = System.Convert.ToString ((int)gems);


		if (collected.Contains (35))
			shovel.GetComponent<Image> ().color = Color.white;
		if (collected.Contains (40))
			pick.GetComponent<Image> ().color = Color.white;
		if (collected.Contains (45))
			tnt.GetComponent<Image> ().color = Color.white;
		if (collected.Contains (33))
			strange.GetComponent<Image> ().color = Color.white;
		if (collected.Contains (15))
			magic.GetComponent<Image> ().color = Color.white;
		if (collected.Contains (17))
			cookie.GetComponent<Image> ().color = Color.white;
		if (collected.Contains (150))
			ancient.GetComponent<Image> ().color = Color.white;
		if (collected.Contains (99))
			drill.GetComponent<Image> ().color = Color.white;
		if (collected.Contains (8))
			heart.GetComponent<Image> ().color = Color.white;
		
	}

	public void addCollected(int itemID){
		if (itemID <= 0)
			gems++;
		else
			collected.AddLast(itemID);
	}
}
