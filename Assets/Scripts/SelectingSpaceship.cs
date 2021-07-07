using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectingSpaceship : MonoBehaviour
{
	public Spaceships Spaceship;
	private bool switcher = true;
	private Button exitCustomizationCheck;

	private void Start()
	{
		if (switcher)
		{
			exitCustomizationCheck = GameObject.Find("Customization Button").GetComponent<Button>();
			exitCustomizationCheck.enabled = false;
			switcher = false;
		}
	}

	public void AddSpaceship()
	{
		if (!switcher)
			exitCustomizationCheck.enabled = true;

		ScrollViewMenu scrollViewMenu = GameObject.Find("CanvasEditor").GetComponent<ScrollViewMenu>();

		Dictionary<Spaceships, GameObject> listSpaceships = scrollViewMenu.ListCreatedSpaceships;

		foreach (var spaceship in listSpaceships)
		{
			if (spaceship.Key.Equals(Spaceship))
			{
				scrollViewMenu.ÑurrentSpaceship = spaceship.Value;
				return;
			}
		}

		GameObject spaceshipInstantiate = Instantiate(Spaceship.GridModuls);

		spaceshipInstantiate.GetComponent<GridBuildingSystem>().SpaceshipArea = Spaceship.QuantityModuls;

		scrollViewMenu.ÑurrentSpaceship = spaceshipInstantiate;

		spaceshipInstantiate.SetActive(false);

		listSpaceships.Add(Spaceship, spaceshipInstantiate);
	}
}
