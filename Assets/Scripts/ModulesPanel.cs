using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ModulesPanel: MonoBehaviour
{
	[SerializeField] private GameObject _moduleCreat;

	//[SerializeField] private List<Product> _products;
	//[SerializeField] private Player _player;
	//[SerializeField] private ProductView _teamlate;
	//[SerializeField] private GameObject _itemContainer;

	//private void Start()
	//{
	//	for (int i = 0; i < _products.Count; i++)
	//	{
	//		AddItem(_products[i]);
	//	}
	//}

	//private void AddItem(Product product)
	//{
	//	var view = Instantiate(_teamlate, _itemContainer.transform);
	//	view.SellButtonClick += OnSellButtonClick;
	//	view.Render(product);
	//}

	//private void TrySellProduct(Product product, ProductView view)
	//{
	//	if (product.Price <= _player.Money)
	//	{
	//		bool bay = _player.BuyProduct(product);
	//		if (bay)
	//		{
	//			product.Buy();
	//			view.SellButtonClick -= OnSellButtonClick;
	//		}
	//	}
	//}

	//private void OnSellButtonClick(Product product, ProductView view)
	//{
	//	TrySellProduct(product, view);
	//}
}
