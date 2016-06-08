using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour {

    public float delayTime;
    private Vector3 PlayerP;

	// Use this for initialization
	void Start ()
    {
        PlayerP = new Vector3(466.6f, 162f, -427.9f);
        StartCoroutine( Go() );
	}
	
	// Update is called once per frame
	IEnumerator Go ()
    {
        while (true)
        {
            //animation.Play();
            yield return new WaitForSeconds(3f);
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.transform.position = new Vector3(466.6f, 162f, -427.9f);
        }
    }
}
