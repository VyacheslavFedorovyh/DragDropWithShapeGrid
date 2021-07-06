using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModuleViewPanel : MonoBehaviour
{
	//[SerializeField] private Image _icon;
	//[SerializeField] private Button _sellButton;

	//private Module _module;

	//public event UnityAction<Module, ModuleViewPanel> SellButtonClick;

	//private void OnEnable()
	//{
	//	_sellButton.onClick.AddListener(OnButtonClick);
	//	_sellButton.onClick.AddListener(TryLockItem);
	//}

	//private void OnDisable()
	//{
	//	_sellButton.onClick.RemoveListener(OnButtonClick);
	//	_sellButton.onClick.RemoveListener(TryLockItem);
	//}

	//private void TryLockItem()
	//{
	//	if (_module.IsBuyed)
	//		_sellButton.interactable = false;
	//}

	//public void Render(Module module)
	//{
	//	_module = module;
	//	_label.text = module.Label;
	//	_price.text = module.Price.ToString();
	//	_icon.sprite = module.Icon;
	//}

	//private void OnButtonClick()
	//{
	//	SellButtonClick?.Invoke(_module, this);
	//}
}
