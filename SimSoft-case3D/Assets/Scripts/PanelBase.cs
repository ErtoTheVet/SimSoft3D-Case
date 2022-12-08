using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimSoft
{
    public abstract class PanelBase : MonoBehaviour
    {
        [Header("Position Settings")] 
        [SerializeField] protected TMP_InputField positionXInputField;
        [SerializeField] protected TMP_InputField positionYInputField;
        [SerializeField] protected TMP_InputField positionZInputField;

        [Header("Rotation Settings"), Space(15)] 
        [SerializeField] protected TMP_InputField rotationXInputField;
        [SerializeField] protected TMP_InputField rotationYInputField;
        [SerializeField] protected TMP_InputField rotationZInputField;

        [Header("References"), Space(15)] [SerializeField]
        protected Button actionButton;

        protected virtual void Update()
        {
            CheckActionButtonState();
        }

        private void CheckActionButtonState()
        {
            if (positionXInputField.text == string.Empty || positionYInputField.text == string.Empty ||
                positionZInputField.text == string.Empty || rotationXInputField.text == string.Empty ||
                rotationYInputField.text == string.Empty || rotationZInputField.text == string.Empty)
            {
                actionButton.interactable = false;
            }
            else
            {
                actionButton.interactable = true;
            }
        }

        private void SetInitialValues()
        {
            positionXInputField.text = "0";
            positionYInputField.text = "0";
            positionZInputField.text = "0";
            rotationXInputField.text = "0";
            rotationYInputField.text = "0";
            rotationZInputField.text = "0";
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
            SetInitialValues();
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}