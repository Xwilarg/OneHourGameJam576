using OneHourJam.Manager;
using UnityEngine;

namespace OneHourJam.World
{
    public class Houses : MonoBehaviour
    {
        private float _timer = 2f;

        private void Update()
        {
            if (!GameManager.Instance.IsPlaying) return;

            _timer -= Time.deltaTime * GameManager.Instance.DifficultyLevel;
            if (_timer <= 0f)
            {
                _timer = 2f;
                GameManager.Instance.LooseFood();
            }
        }
    }
}
