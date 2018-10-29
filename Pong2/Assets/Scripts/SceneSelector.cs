using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public Button button;
    public string level;

	// Use this for initialization
	void Start () {
        Button btn1 = button.GetComponent<Button>();
        btn1.onClick.AddListener(delegate { SceneSelect(level); });
	}
	
	void SceneSelect(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }
}
