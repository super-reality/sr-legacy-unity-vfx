//Copyright (c) 2019 Kai Clavier [kaiclavier.com] Do Not Distribute
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
Preparse STM, insert events at specific characters (H becomes <e=rt,aytch>H)
If auto parse is off, manually type ruby text like "<e=rt,aytch>H" ("rt" means ruby text event, "aytch" is the ruby text to be shown.)
these new events spawn temporary STM objects
 */
[RequireComponent(typeof(SuperTextMesh))]
public class STMRubyText : MonoBehaviour {
	public SuperTextMesh stm;
	public bool autoParse = true;

	public void OnEnable()
	{
		//set up events
		stm.OnCustomEvent += Event;
		if(autoParse)
		{
			stm.OnPreParse += Parse;
		}
		stm.OnRebuildEvent += ClearRubyText;
	}
	public void OnDisable()
	{
		stm.OnCustomEvent -= Event;
		if(autoParse)
		{
			stm.OnPreParse -= Parse;
		}
		stm.OnRebuildEvent -= ClearRubyText;
	}
	public void Reset()
	{
		//get stm component
		stm = GetComponent<SuperTextMesh>();
	}
	[System.Serializable]
	public class Ruby
	{
		public char ch;
		public string text;
	}
	public float verticalOffset = 0f;
	public float rubyTextSize = 0.25f;
	public Ruby[] ruby;
	private List<SuperTextMesh> rubyText = new List<SuperTextMesh>();

	public void Parse(STMTextContainer x)
	{
		//go thru each letter, searching ruby
		for(int i=0; i<x.text.Length; i++)
		{
			//search ruby to see if this letter is a match
			for(int j=0; j<ruby.Length; j++)
			{
				if(x.text[i] == ruby[j].ch)
				{
					x.text = x.text.Insert(i, "<e=rt," + ruby[j].text + ">");
					//skip over this new tag
					i += 7 + ruby[j].text.Length;
				}
			}
		}
	}
	private string[] split;
	private SuperTextMesh tempStm;
	private Vector3 tmpPos;
	public void Event(string text, STMTextInfo info)
	{
		split = text.Split(',');
		//if exactly two strings and first is the rt tag...
		if(split.Length == 2 && split[0] == "rt")
		{
			//create a new STM, and assign the remaining text to it
			tempStm = new GameObject().AddComponent<SuperTextMesh>();
			tempStm.t.SetParent(this.transform); //parent it to this
			tempStm.t.name = split[1];
			//center above letter
			tmpPos.x = info.Middle.x;
			tmpPos.y = info.pos.y + info.size.y + verticalOffset;
			tempStm.t.localPosition = tmpPos;

			tempStm.size = rubyTextSize;
			tempStm.font = stm.font;
			tempStm.color = stm.color;

			tempStm.anchor = TextAnchor.LowerCenter;
			tempStm.alignment = SuperTextMesh.Alignment.Center; //center above letter
			tempStm.autoWrap = info.RelativeWidth; //max width is letter width
			tempStm.bestFit = SuperTextMesh.BestFitMode.OverLimit; //shrink to fit if it goes over

			tempStm.text = split[1];

			rubyText.Add(tempStm); //add to list
		}
	}
	public void ClearRubyText()
	{
		Debug.Log("rebuild was called! clearing " + rubyText.Count + " objects!");
		//destroy gameobjects
		for(int i=0; i<rubyText.Count; i++)
		{
			Destroy(rubyText[i].gameObject);
		}
		//clear list
		rubyText.Clear();
	}
}