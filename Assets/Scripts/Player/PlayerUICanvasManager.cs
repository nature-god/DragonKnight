using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUICanvasManager : MonoBehaviour {

	public Slider HealthSlider;
	public Slider MagicSlider;
	public Slider StaminaSlider;
	// Use this for initialization
	void Awake () {
		Player player = GameManager.Instance.player;
		player.OnHealthChange = OnHealthNumChange;
		player.OnMagicChange = OnMagicNumChange;
		player.OnStaminaChange = OnStaminaNumChange;

		OnHealthNumChange(player.Current_health,player.Health);
		OnMagicNumChange(player.Current_magic,player.Magic);
		OnStaminaNumChange(player.Current_stamina,player.Stamina);
	}
	public void OnHealthNumChange(int current,int max)
	{
		HealthSlider.value = 1.0f*current/max;
		HealthSlider.gameObject.transform.GetChild(2).GetComponent<Text>().text = current+"/"+max;
	}
	public void OnMagicNumChange(int current,int max)
	{
		MagicSlider.value = 1.0f*current/max;
		MagicSlider.gameObject.transform.GetChild(2).GetComponent<Text>().text = current+"/"+max;
	}
	public void OnStaminaNumChange(int current,int max)
	{
		StaminaSlider.value = 1.0f*current/max;
	}
}
