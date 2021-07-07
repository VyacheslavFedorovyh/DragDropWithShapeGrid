using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentSpaceships : MonoBehaviour
{
	[SerializeField] private GameObject _button;
	[SerializeField] private List<Spaceships> _spaceships;

	private void Start()
	{
		for (int i = 0; i < _spaceships.Count; i++)
		{
			GameObject button = Instantiate(_button, gameObject.transform);
			button.GetComponent<Image>().sprite = _spaceships[i].SpriteSpaceship;
			button.GetComponent<ButtonClick>().Spaceship = _spaceships[i];
		}
	}
}
