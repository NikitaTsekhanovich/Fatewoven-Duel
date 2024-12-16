using UnityEngine;

namespace GameControllers.MonobehControllers
{
    public class StopperJumpAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void StopJumpAnimation()
        {
            _animator.SetBool("IsJump", false);
        }
    }
}

