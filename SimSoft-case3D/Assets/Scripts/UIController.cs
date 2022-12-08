using UnityEngine;

namespace SimSoft
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private CreatePanelUI createPanelUI;

        [SerializeField] private MovePanelUI movePanelUI;

        private void Start()
        {
            createPanelUI.Show();
        }

        private void OnEnable()
        {
            createPanelUI.OnCreateCubeButtonClicked += OnCreateCubeButtonClicked;
        }

        private void OnDisable()
        {
            createPanelUI.OnCreateCubeButtonClicked -= OnCreateCubeButtonClicked;
        }

        private void OnCreateCubeButtonClicked()
        {
            createPanelUI.Hide();
            movePanelUI.Show();
        }
    }
}
