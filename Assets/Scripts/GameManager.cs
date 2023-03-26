using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] public ItemClass Ass;

    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //PlayerPrefs.DeleteAll();//Nu wordt alles aan het begin gereset

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

 //   public void Update()
 //   {
  //      if (Input.GetKeyDown(KeyCode.K))
  //      {
  //          InventoryManager.Add(Ass);
    //    }
//
    //}

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public player player;
    //public weapon weapon...
    public FloatingTextManager floatingTextManager;

    //Logic
    /*
     * INT preferedSkin
     * INT pesos
     * INT experience
     * INT weaponLevel
     */

    public int pesos;
    public int experience;

    //Floating text
    public void ShowText(string msg, int fontsize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg,fontsize,color,position,motion,duration);
    }

    #region saving and loading
    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|"; //Zet een int om naar een string
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s); //Je savet op savestate alles wat je aan s hebt toegevoegd (soort boodschappenlijst)
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');


        //Alles wat uit de SaveState komt wordt ingesteld voor de waardes

        //Change player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change the weapon level

        Debug.Log("LoadState");
    }
    #endregion saving and loading
}
