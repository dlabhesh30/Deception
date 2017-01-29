using UnityEngine;
using System.Collections;


public class AssignColor : MonoBehaviour {
	public GameObject c1;
	public GameObject c2;
	public GameObject c3;
	public GameObject t1;
	public GameObject t2;
	public GameObject t3;
	public GameObject t1P;
	public GameObject t2P;
	public GameObject t3P;
	public GameObject textQuestion;
	public GameObject colorQuestion;
	private int color1,color2,color3,question,selector,queIsWord,queIsColor;    
	private Color[] color_name = new Color[8];
	private string[] cNames= new string[8];
	public bool goNext;
	private bool wait;
	// Use this for initialization
	void Start () {
		goNext = false;
		color_name[0]=Color.black;
		color_name[1] = Color.blue;
		color_name[2]=Color.cyan;
		color_name[3]=Color.green; 
		color_name[4]=Color.grey; 
		color_name[5]=Color.magenta;
		color_name[6]=Color.red; 
		color_name[7]=Color.yellow;
		cNames[0]="Black";
		cNames[1]="Blue";
		cNames[2]="Cyan";
		cNames[3]="Green";
		cNames[4]="Grey";
		cNames[5]="Purple";
		cNames[6]="Red";
		cNames[7]="Yellow";
		goNext = true;
		wait = false;
	}
	// Update is called once per frame
	void Update () {
		if(goNext==true ) {
			goNext=false;
			assColor ();
		}
		mouseInput();
	}
	void assColor() {
				//if(wait== false) {
						color1 = Random.Range (0, color_name.Length);				
						c1.renderer.material.color = color_name [color1];
						do {
								color2 = Random.Range (0, color_name.Length);
						} while(color1==color2);
						c2.renderer.material.color = color_name [color2];			
						do {
								color3 = Random.Range (0, color_name.Length);
						} while(color3==color2 || color3==color1);
						c3.renderer.material.color = color_name [color3];
						//Choose a question
						question = Random.Range (0, 2);                    //
						if (question == 0) {                    //select word as question						
								textQuestion.GetComponent<TextMesh> ().text = " Word ";
						} else {                                   //select Color as question					
								textQuestion.GetComponent<TextMesh> ().text = " Color ";
						}            							                   
						selector = Random.Range (0, 2);           //select a color to be asked as question
						if (selector == 0) {                         //select color1					 
								colorQuestion.GetComponent<TextMesh> ().text = cNames [color1];
								queIsWord = color1;
								queIsColor = color1;
						} else                                    //
			if (selector == 1) {                         //select color2					 
								colorQuestion.GetComponent<TextMesh> ().text = cNames [color2];
								queIsWord = color2;
								queIsColor = color2;
						} else                                    //select color3
			if (selector == 2) {				 
								colorQuestion.GetComponent<TextMesh> ().text = cNames [color3];	
								queIsWord = color3;
								queIsColor = color3;
						}    
			
						//display color names in boxes
						// text1
						t1.renderer.material.color = color_name [color1];				
						t1.GetComponent<TextMesh> ().text = cNames [color1];				
			
						// text2				
						t2.renderer.material.color = color_name [color2];				 
						t2.GetComponent<TextMesh> ().text = cNames [color2];
						// text3
						t3.renderer.material.color = color_name [color3];			
						t3.GetComponent<TextMesh> ().text = cNames [color3];				
						wait = true;							
				//}
		}

	void CorrectAns (){
		Debug.Log (" Correct");
		goNext = true;
		wait=false;

	}
	void WrongAns (){
		Debug.Log (" wrong");
		goNext = false;		
		wait=false;
		}

	void mouseInput () {
		//Debug.Log (" in mouse Input");
		if (Input.GetMouseButtonDown (0)) {

						RaycastHit hit;
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						if (Physics.Raycast (ray, out hit, 100)) {	
						   if(hit.collider!= null){				
								if (hit.collider.transform.tag == c1.collider.transform.tag) {
										Debug.Log (" c1");
										if (c1.renderer.material.color == color_name [queIsColor] && question == 1)
											CorrectAns();
										else 
											WrongAns();
								} 

								if (hit.collider.transform.tag == c2.collider.transform.tag) {
										Debug.Log (" c2");
										if (c2.renderer.material.color == color_name [queIsColor] && question == 1)
											CorrectAns();
										else 
											WrongAns();
								} 
								if (hit.collider.transform.tag == c3.collider.transform.tag) {
								        Debug.Log (" c3");
										if (c3.renderer.material.color == color_name [queIsColor] && question == 1)
											CorrectAns();
										else
											WrongAns();
								} 			
								if (hit.collider.transform.tag == t1P.collider.transform.tag) {
										Debug.Log (" t1P");
										if (t1.renderer.material.color == color_name [queIsWord] && question == 0)
											CorrectAns();
										else
											WrongAns();
								}			
								if (hit.collider.transform.tag == t2P.collider.transform.tag) {
										Debug.Log (" t2P");
										if (t2.renderer.material.color == color_name [queIsWord] && question == 0)
											CorrectAns();	
										else
											WrongAns();
								} 			
								if (hit.collider.transform.tag == t3P.collider.transform.tag) {
										Debug.Log (" t3P");
										if (t3.renderer.material.color == color_name [queIsWord]&& question == 0)
											CorrectAns();
										else
											WrongAns();								
								}
							  }
							} 
						}
					}
	}



