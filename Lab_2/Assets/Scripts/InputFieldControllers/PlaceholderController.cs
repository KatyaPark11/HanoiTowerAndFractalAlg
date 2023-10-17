using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlaceholderController : MonoBehaviour
    {
        private TMP_InputField inputField;
        private string placeholderText;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
            placeholderText = inputField.placeholder.GetComponent<TextMeshProUGUI>().text;

            inputField.onSelect.AddListener(OnClickInputField);
            inputField.onDeselect.AddListener(OnDeselectInputField);
        }

        private void OnClickInputField(string value)
        {
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = string.Empty;
        }

        private void OnDeselectInputField(string value)
        {
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = placeholderText;
        }
    }
}