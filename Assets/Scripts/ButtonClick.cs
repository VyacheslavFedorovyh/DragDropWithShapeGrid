using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
	public Spaceships Spaceship;

	public void AddSpaceship()
	{
		ScrollViewMenu scrollViewMenu = GameObject.Find("CanvasEditor").GetComponent<ScrollViewMenu>();
		List <GameObject> _grid = scrollViewMenu.ListCreatedSpaceships;

		GameObject gridModuls = _grid.FirstOrDefault(d => d.Equals(Spaceship.GridModuls));

		if (gridModuls == null)
		{
			GameObject spaceship = Instantiate(Spaceship.GridModuls, Vector3.zero, Quaternion.identity);

			Spaceship.GridModuls.GetComponent<GridBuildingSystem>().SpaceshipArea = Spaceship.QuantityModuls;

			scrollViewMenu.—urrentSpaceship = spaceship;

			_grid.Add(spaceship);

			GameObject.Find("Scroll View Spaceship").SetActive(false);
		}
		else
		{
			Spaceship.GridModuls.GetComponent<GridBuildingSystem>().SpaceshipArea = Spaceship.QuantityModuls;

			scrollViewMenu.—urrentSpaceship = _grid.FirstOrDefault(d => d.Equals(Spaceship.GridModuls));

			scrollViewMenu.Open—urrentSpaceship();			

			GameObject.Find("Scroll View Spaceship").SetActive(false);
		}

	}
}
