using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {

		FoodPlace _place = null;
		float     _timer = 0f;
		[SerializeField]float     _timerBetweenClicks = 0f;
		[SerializeField] bool      _doubleClick = false;
		[SerializeField] bool      _startTimerBetweenClick = false;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		private void Update() {
			if ( _startTimerBetweenClick) {

				_timerBetweenClicks += Time.deltaTime;

				if ( _timerBetweenClicks > 1 ) {
					_startTimerBetweenClick = false;
					_timerBetweenClicks = 0;
				}
				

				if ( Input.GetMouseButtonDown(0) ) {
					_doubleClick = true;
					_timerBetweenClicks = 0;
					_startTimerBetweenClick = false;
				}
			}
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			if ( _place.CurFood == null )
				return;
			if (_place.CurFood.CurStatus == Food.FoodStatus.Overcooked) {
				_startTimerBetweenClick = true;

				if (_doubleClick) {
					_doubleClick = false;
					_place.FreePlace();
				}
			}
		}
	}
}
