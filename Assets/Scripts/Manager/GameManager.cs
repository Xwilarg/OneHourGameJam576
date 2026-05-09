using OneHourJam.World;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OneHourJam.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        [SerializeField]
        private TMP_Text _resourcesText;

        private Camera _cam;

        private int _gold;
        private int _food = 20;

        public int DifficultyLevel => (_gold / 50) + 1;

        public void GainGold()
        {
            _gold++;
            UpdateUI();
        }
        public void GainFood()
        {
            _food++;
            UpdateUI();
        }
        public void LooseFood()
        {
            _food--;
            UpdateUI();
        }

        private void Awake()
        {
            Instance = this;
            _cam = Camera.main;
            UpdateUI();
        }

        private void UpdateUI()
        {
            _resourcesText.text = $"Gold: {_gold}\nFood: {_food}";
        }

        public void OnClick(InputAction.CallbackContext value)
        {
            if (value.phase == InputActionPhase.Started)
            {
                var ray = _cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                var hit = Physics2D.GetRayIntersection(ray, float.MaxValue, LayerMask.GetMask("Prop"));
                if (hit.collider != null && hit.collider.TryGetComponent<IInteractible>(out var comp))
                {
                    comp.Click();
                }
            }
        }
    }
}
