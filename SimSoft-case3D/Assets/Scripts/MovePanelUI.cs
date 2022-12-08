using TMPro;
using UnityEngine;

namespace SimSoft
{
    public class MovePanelUI : PanelBase
    {
        [SerializeField] private TMP_InputField durationInput;
        [SerializeField] private TMP_Text distanceText;
        private CubeObject _cubeObject;

        private void Awake()
        {
            _cubeObject = FindObjectOfType<CubeObject>();
        }

        protected override void Update()
        {
            if (positionXInputField.text == string.Empty || positionYInputField.text == string.Empty ||
                positionZInputField.text == string.Empty || rotationXInputField.text == string.Empty ||
                rotationYInputField.text == string.Empty || rotationZInputField.text == string.Empty ||
                durationInput.text == string.Empty)
            {
                actionButton.interactable = false;
            }
            else
            {
                actionButton.interactable = true;
            }
        }

        private void Move()
        {
            var duration = float.Parse(durationInput.text);
            var position = new Vector3(float.Parse(positionXInputField.text), float.Parse(positionYInputField.text),
                float.Parse(positionZInputField.text));
            var rotation = new Vector3(float.Parse(rotationXInputField.text), float.Parse(rotationYInputField.text),
                float.Parse(rotationZInputField.text));

            float distance = Vector3.Distance(_cubeObject.transform.position, position);
            distanceText.text = $"Distance is: {distance:#.##}m";

            _cubeObject.SetPositionAndRotationSmooth(position, rotation, duration);
        }

        public override void Show()
        {
            base.Show();
            actionButton.onClick.AddListener(Move);
        }

        public override void Hide()
        {
            base.Hide();
            actionButton.onClick.RemoveListener(Move);
        }
    }
}