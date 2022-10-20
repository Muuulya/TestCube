using UnityEngine;
using UnityEngine.UI;

public class InputFieldChangeCheck : MonoBehaviour
{
    private InputField _inputField;

    void Awake()
    {
        _inputField = gameObject.GetComponent<InputField>();
    }

    private void OnEnable()
    {
        _inputField.onValueChanged.AddListener(ChangeCheck);
    }

    private void OnDisable()
    {
        _inputField.onValueChanged.RemoveListener(ChangeCheck);
    }

    private void ChangeCheck(string text)
    {
        if (text.Length > 0 && (text[0] == '-' || text[0] == '0'))
        {
            _inputField.text = text.Remove(0, 1);
        }
    }
}
