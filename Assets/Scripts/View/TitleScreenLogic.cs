using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreenLogic : Selectable
{
	public GameObject Title;
	public GameObject Settings;
	public GameObject Controls;
	public GameObject Audio;
	public GameObject Graphics;

	TitleScreenFade fade;
	GameObject screen;
	public void StartGame()
	{
		screen = GameObject.FindWithTag("Fade");
		fade = screen.GetComponent<TitleScreenFade>();
		fade.FadeOut();
		//Debug.Log("Changing to scene1");
	}
	
	public void Quit()
	{
		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false;
	}

	public void GoToSettings()
	{
		Title.SetActive(false);
		Settings.SetActive(true);
		
	}

	public void BackToMainMenu()
    {
		Title.SetActive(true);
		Settings.SetActive(false);
	}

	public void GoToControls()
    {
		Settings.SetActive(false);
		Controls.SetActive(true);
	}

	public void BackToSettings()
    {
		Settings.SetActive(true);
		Controls.SetActive(false);
		Audio.SetActive(false);
		Graphics.SetActive(false);
	}

	public void GoToAudio()
    {
		Settings.SetActive(false);
		Audio.SetActive(true);
    }

	public void GoToGraphics()
    {
		Settings.SetActive(false);
		Graphics.SetActive(true);
    }

}