using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _project_name.Services
{
    public class ButtonClickHandler : MonoBehaviour
    {
        [SerializeField] private Button button;
        private InputManager inputManager;


        public void OnPointerEnter()
        {
            Debug.Log("OnPointerEnter");
            //     inputManager.gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(InputManager inputManager)
        {
            this.inputManager = inputManager;
        }
    }
}