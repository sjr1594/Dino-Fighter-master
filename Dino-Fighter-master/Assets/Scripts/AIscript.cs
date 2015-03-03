using UnityEngine;
using System.Collections;

public class AIscript : MonoBehaviour {
	public MoveClass[] moveArr;
	public FrankController eve;
	public FrankController adam;

	// Use this for initialization
	void Start () {
		moveArr = GameObject.Find ("Main Camera").GetComponent<MoveDictionary> ().getMoves("king");
	}
	
	// Update is called once per frame
	void Update () {
	}

	/* move list for frank in moveArr: 
	 * 0-light attack
	 * 1-medium attack
	 * 2-heavy attack
	 * 3-fireball
	 * 4-dino punch
	 * 5-throw
	 * 6-air attack
	 * 7-forward dash
	 * 8-back dash
	 * 9-defend
	 * 10-forward
	 * 11-back
	*/
	public void TakeAIturn(){
		//determine distance between players, set it to close 0 - 2, med 2 - 4, far 4+;
		int closeCap = 2;
		int medCap = 4;
		float distance = Mathf.Abs(adam.transform.position.x - eve.transform.position.x);
		
		//get a random number to choose if the AI will be offensive or defensive. 0 will be offense, 1 will be defense.
		int choice = Random.Range (0, 2);
		print (choice + "c");
		print (adam.transform.position.x + "A");
		print (eve.transform.position.x + "E");
		if (distance < closeCap) {
			if (choice == 0) {
				//offensive close
				//heavy attack
				eve.addMove (moveArr [2]);
				print ("OC");
			} else if (choice == 1) {
				//defensive close
				//defend, light, defend
				eve.addMove (moveArr [9]);
				eve.addMove (moveArr [0]);
				eve.addMove (moveArr [9]);
				print ("DC");
			}
		} else if (distance < medCap) {
			if (choice == 0) {
				//offensive medium
				//forward, medium attack
				eve.addMove (moveArr [10]);
				eve.addMove (moveArr [1]);
				print ("OM");
				
			} else if (choice == 1) {
				//defensive medium
				//defend forward forward
				eve.addMove (moveArr [9]);
				eve.addMove (moveArr [10]);
				eve.addMove (moveArr [10]);
				print ("DM");
				
			}
		} else {
			if (choice == 0) {
				//offensive far
				//fireball
				eve.addMove (moveArr [3]);
				print ("OF");
				
			} else if (choice == 1) {
				//defensive far
				//forward dash (more neutral just to move closer)
				eve.addMove (moveArr [7]);
				print ("DF");
				

			}
		}
	}
}
