using UnityEngine;
using UnityEngine.SceneManagement;

// this class will reset the game if abuhasan dies at some point in the game
public class GameManager : MonoBehaviour
{
    public static GameManager Instances { get; private set; }

    public int world{get; private set;}
    public int stage{get; private set;}
    public int lives{get; private set;}

    private void Awake()
    {
        if( Instances != null)
        {
            DestroyImmediate(gameObject);
        }
        else {
            Instances = this; 
            DontDestroyOnLoad(gameObject); // dont destrot this game object whenever we go to different levels
        }
    }

    private void onDestroy(){
        if(Instances == this){
            Instances = null;
        }
    }

    void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        lives =3; 
        LoadLevel(1,1);
    }
    private void LoadLevel(int w , int s)
    {
        w = world;
        s = stage;   

        // make sure that all the scenes are called approprietly
        SceneManager.LoadScene($"{world} - {stage}"); 
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel) , delay);
    }

    public void ResetLives()
    {
        lives--;

        if(lives>0){
            LoadLevel(world,stage);
        }
        else {
            GameOver();
        }
    }

    private void GameOver(){
        NewGame();
    }

    public void NextLevel()
    {
        LoadLevel(world,stage + 1);
    }
}
