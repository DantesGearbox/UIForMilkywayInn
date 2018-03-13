 using UnityEngine;

namespace MadsUI {
	public class MenuPop : MonoBehaviour {

		private RectTransform rectTransform;

		bool popIn = false;
		float popTimer = 0.5f;
		float popTime = 0.0f;

		[HideInInspector] public float menuWidth = 236.0f;
		[HideInInspector] public float menuHeight = 123.0f;

		private void Start() {
			rectTransform = GetComponent<RectTransform>();
		}

		public void PopIn() {
			popIn = true;
			popTime = 0.0f;
		}

		public void PopOut() {
			popIn = false;
			popTime = popTimer;
		}

		public void Update() {
			if (popIn) {
				popTime += Time.deltaTime;
				if(popTime < popTimer) {
					rectTransform.sizeDelta = new Vector2(EaseOut(popTime, 0, menuWidth, popTimer), menuHeight);
				} else {
					rectTransform.sizeDelta = new Vector2(menuWidth, menuHeight);
				}
			} else {
				popTime -= Time.deltaTime;
				if(popTime > 0) {
					rectTransform.sizeDelta = new Vector2(EaseIn(popTime, 0, menuWidth, popTimer), menuHeight);
				} else {
					rectTransform.sizeDelta = new Vector2(0.0f, menuHeight);
				}
			}
		}

		//T is timestep, B is start, C is difference between end and start, D is the total easing time
		private float EaseIn(float t, float b, float c, float d) {
			if (t == 0)
				return b;
			if ((t /= d) == 1)
				return b + c;
			float p = d * .3f;
			float a = c;
			float s = p / 4;
			float postFix = a * Mathf.Pow(2, 10 * (t -= 1));
			return -(postFix * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p)) + b;
		}

		private float EaseOut(float t, float b, float c, float d) {
			if (t == 0) return b;
			if ((t /= d) == 1) return b + c;
			float p = d * .3f;
			float a = c;
			float s = p / 4;
			return (a * Mathf.Pow(2, -10 * t) * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p) + c + b);
		}
	}
}
