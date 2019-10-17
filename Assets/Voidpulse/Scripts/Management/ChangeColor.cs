using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

	MeshRenderer myRenderer;
	Material myMaterial;
	Color originalColor;
	public Color selectColor;

	float hue, saturation, value;

	private bool Toggle = false;

    void Start() {
		myRenderer = this.GetComponent<MeshRenderer>();
		myMaterial = myRenderer.material;
		originalColor = myMaterial.color;
		Color.RGBToHSV(originalColor, out hue, out saturation, out value);
	}

	void Update(){

		if (Global.ColorShifter >= 0.01f){
			//convert original color to HSV values
			Color.RGBToHSV(myMaterial.color, out hue, out saturation, out value);
			float shifter = Global.ColorShifter * 0.01f;
			hue = Mathf.Repeat(hue + shifter, 1);

			myMaterial.color = Color.HSVToRGB(hue, saturation, value);
		}
		/*

		*/
	}

	public void increaseColorBrightness() 
	{
		saturation = saturation - 0.25f;
		myMaterial.color = Color.HSVToRGB(hue, saturation, value);
		/* 
		originalColor = myMaterial.color;

		//convert original color to HSV values
		float hue, saturation, value;
		Color.RGBToHSV(originalColor, out hue, out saturation, out value);

		//lower saturation
		saturation = saturation - 0.5f;

		//change to render with new lightness value
		myMaterial.color = Color.HSVToRGB(hue, saturation, value);
		*/
	}

	public void toggleColorHue() 
	{
		if(Toggle)
		{
			hue = Mathf.Repeat(hue - 0.7f, 1);
			myMaterial.color = Color.HSVToRGB(hue, saturation, value);
			Toggle = false;
		} else {
			hue = Mathf.Repeat(hue + 0.7f, 1);
			myMaterial.color = Color.HSVToRGB(hue, saturation, value);
			Toggle = true;
		}
	}
	public void changeColor() {
		myMaterial.color = selectColor;
	}

	public void changeColorBack() {
		//myMaterial.color = originalColor;
		saturation = saturation + 0.25f;
		myMaterial.color = Color.HSVToRGB(hue, saturation, value);
	}

	public void AlterColor(Color color)
	{
		//change color to new passed color 
		myMaterial.color = color;
	}

	public void toggleColor() {
		if (myMaterial.color == originalColor)
			myMaterial.color = selectColor;
		else
			myMaterial.color = originalColor;
	}
}
