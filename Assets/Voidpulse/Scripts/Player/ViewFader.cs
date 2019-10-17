
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewFader : MonoBehaviour {

	public Animator Animator;

	public void FadeToLevel () {

		Animator.SetTrigger("FadeOut");

	}

	public void FadeInLevel () {

		Animator.SetTrigger("FadeIn");

	}
}
