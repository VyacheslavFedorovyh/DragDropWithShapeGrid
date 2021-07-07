using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickModule : MonoBehaviour
{
	public Module module;
	public static GameObject itemBeingDragged;

	private RectTransform _rectTransform;

	public void AddModule()
	{
		Vector3Int size = module.area.size / 2;

		Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		vec = new Vector3(vec.x - size.x, vec.y - size.x, 0);

		itemBeingDragged = Instantiate(module, vec, Quaternion.identity).gameObject;

		_rectTransform = itemBeingDragged.GetComponent<RectTransform>();

		_rectTransform.SetAsLastSibling();
	}
}
