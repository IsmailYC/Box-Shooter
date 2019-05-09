using UnityEngine;
using System.Collections;

public class TargetExit : MonoBehaviour
{
	public float exitAfterSeconds = 10f; // how long to exist in the world
	public float exitAnimationSeconds = 1f; // should be >= time of the exit animation

	private bool startDestroy = false;

	// Use this for initialization
	void Start ()
	{
        Invoke("StartExit", exitAfterSeconds);
	}

    void StartExit()
    {
        if (GetComponent<Animator>() == null)
            // no Animator so just destroy right away
            Destroy(gameObject);
        else if (!startDestroy)
        {
            // set startDestroy to true so this code will not run a second time
            startDestroy = true;

            // trigger the Animator to make the "Exit" transition
            GetComponent<Animator>().SetTrigger("Exit");

            // Call KillTarget function after exitAnimationSeconds to give time for animation to play
            Invoke("KillTarget", exitAnimationSeconds);
        }
    }

	// destroy the gameObject when called
	void KillTarget ()
	{
		// remove the gameObject
		Destroy (gameObject);
	}
}
