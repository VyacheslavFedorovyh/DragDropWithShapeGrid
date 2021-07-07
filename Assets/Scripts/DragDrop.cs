using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
	private GridBuildingSystem buildingSystem;
	private Module _module;
	private Vector3 prevPos;
	private string _nameGrid;

	private void Start()
	{
		_module = GetComponent<Module>();

		ScrollViewMenu scrollViewMenu = GameObject.Find("CanvasEditor").GetComponent<ScrollViewMenu>();

		_nameGrid = scrollViewMenu.ÑurrentSpaceship.name;

		buildingSystem = GameObject.Find(_nameGrid).GetComponent<GridBuildingSystem>();
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

		Vector3Int cellPos = buildingSystem.GridLayout.LocalToCell(touchPos);

		if (prevPos != cellPos)
		{
			_module.transform.localPosition = buildingSystem.GridLayout.CellToLocalInterpolated(cellPos);

			prevPos = cellPos;
			buildingSystem.FollowBuilding(_module);
		}
	}
}
