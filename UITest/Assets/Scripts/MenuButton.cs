using UnityEngine;
using UnityEngine.EventSystems;

namespace MadsUI {
	public class MenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

		public MenuPop menuPop;
		private bool clicked = false;

		public void OnPointerClick(PointerEventData eventData) {

			Debug.Log("Clicked");

			if (!clicked) {
				menuPop.PopIn();
				clicked = true;
			} else {
				menuPop.PopOut();
				clicked = false;
			}
		}

		public void OnPointerEnter(PointerEventData eventData) {
			Debug.Log("Enter");
			//menuPop.PopIn();
		}

		public void OnPointerExit(PointerEventData eventData) {
			Debug.Log("Exit");
			//menuPop.PopOut();
		}
	}
}
