using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
	[SerializeField] private GameObject _moduleCreat;

	private GridBuildingSystem buildingSystem;
	private Module _module;
	private Vector3 prevPos;

	private void Start()
	{
		_module = GetComponent<Module>();
		buildingSystem = GameObject.Find("Grid").GetComponent<GridBuildingSystem>();
	}

	private void OnMouseDown()
	{
		_module = Instantiate(_moduleCreat, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity).GetComponent<Module>();
	}

	private void OnMouseDrag()
	{
		if (EventSystem.current.IsPointerOverGameObject(0))
			return;

		if (_module.Placed)
			FollowMouse();
		else
		{
			_module.Place(true);
			FollowMouse();
		}
	}

	private void OnMouseUp()
	{
		_module.Place(false);
	}

	private void FollowMouse()
	{
		Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector3Int cellPos = buildingSystem.GridLayout.LocalToCell(touchPos);

		if (prevPos != cellPos)
		{
			_module.transform.localPosition = buildingSystem.GridLayout.CellToLocalInterpolated(cellPos);

			prevPos = cellPos;
			buildingSystem.FollowBuilding(_module);
		}
	}
}
