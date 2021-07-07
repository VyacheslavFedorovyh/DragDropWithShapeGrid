using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseСurrentSpaceshipCheck : MonoBehaviour
{
	[SerializeField] private BoundsInt _area;
	[SerializeField] private bool _check;
	[SerializeField] private GameObject _exitCustomizationButton;

	public void OnMouseDownCheck(GameObject panel)
	{
		ScrollViewMenu scrollViewMenu = GameObject.Find("CanvasEditor").GetComponent<ScrollViewMenu>();

		GridBuildingSystem gridBuildingSystem = scrollViewMenu.СurrentSpaceship.GetComponent<GridBuildingSystem>();

		_check = gridBuildingSystem.TakeAreaEmpty(_area);

		if (_check)
			panel.SetActive(true);
		else
		{
			_exitCustomizationButton.SetActive(true);

			_exitCustomizationButton.GetComponent<Button>().onClick.Invoke();

			_exitCustomizationButton.SetActive(false);
		}
	}

	public void OnMouseDownReturnCustomization(GameObject panel)
	{
		panel.GetComponent<Button>().enabled = true;
	}
}
