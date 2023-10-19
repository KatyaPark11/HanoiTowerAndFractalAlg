using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class NumberInputValidator : MonoBehaviour
    {
        private TMP_InputField inputField;
        public GameObject AnimatedObject;
        private Animator errorAnimator;
        public Button AlgBuildingButton;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
            inputField.onValueChanged.AddListener(ValidateInput);

            errorAnimator = AnimatedObject.GetComponent<Animator>();
        }

        public void ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input) || (input.Contains('-') && input.Length == 1))
            {
                AlgBuildingButton.interactable = false;
                if (AnimatedObject.activeSelf)
                    AnimatedObject.SetActive(false);
            }
            else if (int.TryParse(input, out int value) && value < 2 || value > 20)
            {
                if (AlgBuildingButton.interactable)
                    AlgBuildingButton.interactable = false;
                AnimatedObject.SetActive(true);
                errorAnimator.Play("ErrorMessage", -1, 0f);
            }
            else if (!AlgBuildingButton.interactable)
            {
                AlgBuildingButton.interactable = true;
                if (AnimatedObject.activeSelf)
                    AnimatedObject.SetActive(false);
            }
        }
    }
}