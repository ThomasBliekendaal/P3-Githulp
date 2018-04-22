using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrNordicAxeScript : MonoBehaviour {

	public bool active;
    public Collider c;
    public int score;
    public string scoreText;
    public GameObject textObject;
    public bool win;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            if(active == false)
            {
                active = true;
                StartCoroutine(S());
            }
        }
        if (score == 3)
        {
            win = true;
        }
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (active == true)
        {
            if (collision.gameObject.tag == ("Enemy"))
            {
                score += 1;
                Destroy(collision.gameObject);
                scoreText = score.ToString();
            }
        }
    }

    public IEnumerator S()
    {
        c.isTrigger = false;
        transform.Rotate(new Vector3(45, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Back();
    }

    public void Back()
    {
        c.isTrigger = false;
        transform.Rotate(new Vector3(-45, 0, 0));
        active = false;
    }
}
