using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to transform the current GameObject
	public class LeanTranslate : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("Does translation require an object to be selected?")]
		public LeanSelectable RequiredSelectable;

		[Tooltip("The camera the translation will be calculated using (default = MainCamera)")]
		public Camera Camera;

#if UNITY_EDITOR
		protected virtual void Reset()
		{
			Start();
		}
#endif

		protected virtual void Start()
		{
			if (RequiredSelectable == null)
			{
				RequiredSelectable = GetComponent<LeanSelectable>();
			}
		}

		protected virtual void Update()
		{
			// If we require a selectable and it isn't selected, cancel translation
			if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
			{
				return;
			}

			// Get the fingers we want to use
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount, RequiredSelectable);

			// Calculate the screenDelta value based on these fingers
			var screenDelta = LeanGesture.GetScreenDelta(fingers);
            if (fingers != null) {
                if (fingers.Count == 0)
                {
                    if (SceneManager.Instance.getCharacter() != null) {
                        SceneManager.Instance.getCharacter().GetComponent<Ziv>().SetMovingState(false);
                    }

                   // GameObject.FindWithTag("ziv").GetComponent<Ziv>().SetMovingState(false);
                }
            }

			// Perform the translation
			Translate(screenDelta);
		}

		protected virtual void Translate(Vector2 screenDelta)
		{
			// If camera is null, try and get the main camera, return true if a camera was found
			if (LeanTouch.GetCamera(ref Camera) == true)
			{
				// Screen position of the transform
				var screenPosition = Camera.WorldToScreenPoint(transform.position);

				// Add the deltaPosition
				screenPosition += (Vector3)screenDelta;

				// Convert back to world space
				 //transform.position = Camera.ScreenToWorldPoint(screenPosition);

                if (!AppManager.Instance.isAppUserInteractable) { return; }

                Vector3 pos = Camera.ScreenToWorldPoint(screenPosition);
                LeanSelectable selectable = GetComponent<LeanSelectable>();;
                if (selectable.gameObject.tag == "ziv" && (System.Math.Abs(screenDelta.x) > 0.0f || System.Math.Abs(screenDelta.y) > 0.0f))
                {
                    if (!selectable.gameObject.GetComponent<Ziv>().IsLocked()) {
                        pos.y = selectable.transform.position.y;
                        transform.position = pos;
                        selectable.gameObject.GetComponent<Ziv>().SetMovingState(true);
                    }
                } 


                //if (selectable.gameObject.name == "ziv_apron_Deci") {                     //selectable.gameObject.GetComponent<Ziv>().activateMoveAnimation();                 //}
			}
		}
	}
}