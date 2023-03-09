using System.Collections;
using UnityEngine;

public abstract class State : MonoBehaviour
{
	protected StateMachine stateMachine;

	public void Init(StateMachine stateMachine) => this.stateMachine = stateMachine;

	public abstract void OnEnter();

	public abstract void OnUpdate();

	public abstract void OnExit();
}
