using CookingPrototype.Controllers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CookingPrototype.UI {
	public class StartWindow : MonoBehaviour {
		public Button StartButton = null;
		public TMP_Text TargetText = null;
		public GameObject TapBlock = null;

		private void Awake() {
			TapBlock.SetActive(true);
		}

		private void Update() {
			Show();
		}

		public void Show() {
			var gc = GameplayController.Instance;
			Time.timeScale = 0;
			TargetText.text = $"{gc.OrdersTarget}";
		}

		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}
