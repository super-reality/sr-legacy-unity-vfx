using UnityEngine;
using UnityEngine.SceneManagement;

namespace ParticleBackgrounds

{
public class PBSceneSelect : MonoBehaviour
{
	public bool GUIHide = false;
	
    public void LoadPBScene01(){SceneManager.LoadScene("sc_achievement");}
    public void LoadPBScene02(){SceneManager.LoadScene("sc_beans");}
	public void LoadPBScene03(){SceneManager.LoadScene("sc_beans2");}
	public void LoadPBScene04(){SceneManager.LoadScene("sc_boba");}
	public void LoadPBScene05(){SceneManager.LoadScene("sc_boba2");}
	public void LoadPBScene06(){SceneManager.LoadScene("sc_carbonated");}
	public void LoadPBScene07(){SceneManager.LoadScene("sc_digital");}
	public void LoadPBScene08(){SceneManager.LoadScene("sc_disco");}
	public void LoadPBScene09(){SceneManager.LoadScene("sc_disco2");}
	public void LoadPBScene10(){SceneManager.LoadScene("sc_hearts");}
	public void LoadPBScene11(){SceneManager.LoadScene("sc_retro");}
	public void LoadPBScene12(){SceneManager.LoadScene("sc_risingstars");}
	public void LoadPBScene13(){SceneManager.LoadScene("sc_skulls");}
	public void LoadPBScene14(){SceneManager.LoadScene("sc_skulls2");}
	public void LoadPBScene15(){SceneManager.LoadScene("sc_trypo");}

	void Update ()
	 {
 
     if(Input.GetKeyDown(KeyCode.J))
	 {
         GUIHide = !GUIHide;
     
         if (GUIHide)
		 {
             GameObject.Find("DemoCanvas").GetComponent<Canvas> ().enabled = false;
         }
		 else
		 {
             GameObject.Find("DemoCanvas").GetComponent<Canvas> ().enabled = true;
         }
     }
	 }
}
}