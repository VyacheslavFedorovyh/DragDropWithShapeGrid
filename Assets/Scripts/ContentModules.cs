using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentModules: MonoBehaviour
{
	[SerializeField] private GameObject _button;
	[SerializeField] private List<Module> _moduls;

	private void Start()
	{
		for (int i = 0; i < _moduls.Count; i++)
		{
			GameObject button = Instantiate(_button, gameObject.transform);
			button.GetComponent<Image>().sprite = _moduls[i].IconButton;
			button.GetComponent<ButtonClickModule>().module = _moduls[i];
		}
	}
}
