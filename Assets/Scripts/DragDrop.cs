using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
	private GridBuildingSystem _buildingSystem;
	private GameObject _currentSpaceship;	
	private Vector3Int _prevPos;
	private string _nameGrid;
	private Module _module;

	private void Start()
	{
		_module = GetComponent<Module>();

		ScrollViewMenu scrollViewMenu = GameObject.Find("CanvasEditor").GetComponent<ScrollViewMenu>();

		_nameGrid = scrollViewMenu.ÑurrentSpaceship.name;

		_currentSpaceship = GameObject.Find(_nameGrid);

		gameObject.transform.SetParent(_currentSpaceship.transform);

		_buildingSystem = _currentSpaceship.GetComponent<GridBuildingSystem>();
	}

	private void OnMouseDrag()
	{
		if (EventSystem.current.IsPointerOverGameObject(0))
			return;

		if (_module.Placed == null)
		{
			FollowMouse();
			return;
		}

		if (_module.Placed == true)
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

		Vector3Int cellPos = _buildingSystem.GridLayout.LocalToCell(touchPos);

		if (_prevPos != cellPos)
		{
			_module.transform.localPosition = _buildingSystem.GridLayout.CellToLocalInterpolated(cellPos);

			_prevPos = cellPos;
			_buildingSystem.FollowBuilding(_module);
		}
	}
}
