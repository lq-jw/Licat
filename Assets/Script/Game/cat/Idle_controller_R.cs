using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_controller_R : StateMachineBehaviour
{
    [SerializeField]
    private float _timeUntilIdle;

    [SerializeField]
    private int _numberOfIdleAni;

    private bool _isIdle;
    private float _idleTime;
    private int _idleAni;

    // is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_isIdle)
        {
            _idleTime += Time.deltaTime;

            if (_idleTime > _timeUntilIdle && stateInfo.normalizedTime % 1 < 0.02f)
            {
                _isIdle = true;
                _idleAni = Random.Range(1, _numberOfIdleAni + 1);
                _idleAni = _idleAni * 2 - 1;

                animator.SetFloat("idleSwitch_R", _idleAni - 1);
            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetIdle();
        }

        animator.SetFloat("idleSwitch_R", _idleAni, 0.2f, Time.deltaTime);
    }

    private void ResetIdle()
    {
        if (_isIdle)
        {
            _idleAni--;
        }

        _isIdle = false;
        _idleTime = 0;
    }
}
