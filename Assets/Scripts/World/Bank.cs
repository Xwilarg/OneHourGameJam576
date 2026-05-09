using OneHourJam.Manager;
using TMPro;
using UnityEngine;

namespace OneHourJam.World
{
    public class Bank : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private TMP_Text _helpText;

        public void Click()
        {
            _helpText.gameObject.SetActive(false);
            GameManager.Instance.GainGold();
        }
    }
}
