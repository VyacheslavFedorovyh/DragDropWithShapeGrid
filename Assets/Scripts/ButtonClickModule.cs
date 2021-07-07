using UnityEngine;

public class ButtonClickModule : MonoBehaviour
{
	public Module Module;
	public static GameObject ItemBeingDragged;

	private RectTransform _rectTransform;

	public void AddModule()
	{
		Vector3Int size = Module.area.size / 2;

		Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		vec = new Vector3(vec.x - size.x, vec.y - size.x, 0);

		ItemBeingDragged = Instantiate(Module, vec, Quaternion.identity).gameObject;

		_rectTransform = ItemBeingDragged.GetComponent<RectTransform>();

		_rectTransform.SetAsLastSibling();
	}
}
