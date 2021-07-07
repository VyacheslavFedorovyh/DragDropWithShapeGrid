using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectingSpaceship : MonoBehaviour
{
	public Spaceships Spaceship;

	public void AddSpaceship()
	{
		ScrollViewMenu scrollViewMenu = GameObject.Find("CanvasEditor").GetComponent<ScrollViewMenu>();

		Dictionary<Spaceships, GameObject> listSpaceships = scrollViewMenu.ListCreatedSpaceships;

		foreach (var spaceship in listSpaceships)
		{
			if (spaceship.Key.Equals(Spaceship))
			{
				scrollViewMenu.�urrentSpaceship = spaceship.Value;
				return;
			}
		}

		GameObject spaceshipInstantiate = Instantiate(Spaceship.GridModuls);

		spaceshipInstantiate.GetComponent<GridBuildingSystem>().SpaceshipArea = Spaceship.QuantityModuls;

		scrollViewMenu.�urrentSpaceship = spaceshipInstantiate;

		spaceshipInstantiate.SetActive(false);

		listSpaceships.Add(Spaceship, spaceshipInstantiate);
	}
}
