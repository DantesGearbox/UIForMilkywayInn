using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MadsUI {
	public class Scalable : MonoBehaviour {

		public MadsUI.MenuPop menuPop;

		public List<GameObject> buttons = new List<GameObject>();
		private List<GameObject> instancedButtons = new List<GameObject>();

		private void Awake() {

			foreach (Transform child in transform) {
				Destroy(child.gameObject);
			}

			if (buttons.Count > 0) {
				menuPop.menuWidth = 40;
			}

			foreach (GameObject go in buttons) {

				GameObject i = Instantiate(go);
				instancedButtons.Add(i);
				i.transform.SetParent(this.transform);

				menuPop.menuWidth += 100;
			}
		}



	}
}
