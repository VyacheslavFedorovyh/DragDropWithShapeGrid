using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spaceship", menuName = "Spaceship/Create", order = 51)]
public class Spaceships : ScriptableObject
{
	public Sprite SpriteSpaceship;
	public GameObject GridModuls;
	public int QuantityModuls;
}
