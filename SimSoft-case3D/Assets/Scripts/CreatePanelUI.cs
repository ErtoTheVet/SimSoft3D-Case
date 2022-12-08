using System;
using UnityEngine;

namespace SimSoft
{
    public class CreatePanelUI : PanelBase
    {
        private CubeObject _cubeObject;
        public Action OnCreateCubeButtonClicked;
        
        public void OnClickCreate()
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _cubeObject = cube.AddComponent<CubeObject>();
            var position = new Vector3(float.Parse(positionXInputField.text), float.Parse(positionYInputField.text),
                float.Parse(positionZInputField.text));
            var rotation = new Vector3(float.Parse(rotationXInputField.text), float.Parse(rotationYInputField.text),
                float.Parse(rotationZInputField.text));
            _cubeObject.SetPositionAndRotationInstant(position, rotation);

            OnCreateCubeButtonClicked?.Invoke();
        }

        public override void Show()
        {
            base.Show();
            actionButton.onClick.AddListener(OnClickCreate);
        }

        public override void Hide()
        {
            base.Hide();
            actionButton.onClick.RemoveListener(OnClickCreate);
        }
    }
}