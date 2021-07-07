using System.Collections.Generic;
using UnityEngine;

public class ScrollViewMenu : MonoBehaviour
{
	public Dictionary<Spaceships, GameObject> ListCreatedSpaceships = new Dictionary<Spaceships, GameObject>();

	public GameObject —urrentSpaceship;

	public void OpenPanel(GameObject panel)
	{
		panel.SetActive(true);
	}

	public void ClosePanel(GameObject panel)
	{
		panel.SetActive(false);
	}

	public void Open—urrentSpaceship()
	{
		—urrentSpaceship.SetActive(true);
	}

	public void Close—urrentSpaceship()
	{
		—urrentSpaceship.SetActive(false);
	}
}

