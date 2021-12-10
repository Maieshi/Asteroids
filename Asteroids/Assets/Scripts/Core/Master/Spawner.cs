using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    AsteriodTreeManager manager;

    public static Spawner Singleton;

    public Transform ship;

    public GameObject particles;

    [Range(1,6)]
    public int maxAsteroidTreeCount, maxUFOCount;

    public GameObject[] asteroidList;

    public GameObject[] ufoList;

    public Transform[] spawnpoints;

    MyNodeEvent spawnEvent = new MyNodeEvent(); 

    public MyIntEvent scoreEvent = new MyIntEvent();

    public TimerRand spawnAsteroid;

    public TimerRand spawnUFO;

    int ufoCount;

    private void Awake() {
        if (Singleton == null) {
            Singleton = this;
        } else if (Singleton == this) {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        Prepare();
    }

    void Prepare()
    {
        manager = new AsteriodTreeManager();
        spawnEvent.AddListener(manager.CreateTree);
        ufoCount=0;
        spawnAsteroid.EvSignal.AddListener(SpawnAsteroid);
        spawnUFO.EvSignal.AddListener(SpawnUFO);
        spawnAsteroid.Tik(true);
        spawnUFO.PauseTik(true);
    }

    void SpawnAsteroid()
    {
        
        if(manager.listCount<maxAsteroidTreeCount)
        {
            GameObject obj = Instantiate(asteroidList[Settings.Singleton.MyRand(0,2)],spawnpoints[Settings.Singleton.MyRand(0,3)].position,Quaternion.identity);

            Asteroid asteroid =  obj.GetComponent<Asteroid>();
            asteroid.speedScale = 1;
            asteroid.asteroidNode = new AsteroidTreeNode(null);
            
            spawnEvent.Invoke(asteroid.asteroidNode);
            asteroid.EvDeath.AddListener(OnObjectDestroy);
        }
        
    }

    void SpawnUFO()
    {
        if(ufoCount<maxUFOCount)
        {
            ufoCount++;
            UFO ufo = Instantiate(ufoList[Settings.Singleton.MyRand(0,1)],spawnpoints[Settings.Singleton.MyRand(0,3)].position,Quaternion.identity).GetComponent<UFO>();
            ufo.target = ship;
        }
    }


    public void OnObjectDestroy(GameObject obj)
    {

       

        Instantiate(particles,obj.transform.position,Quaternion.identity);
        Asteroid asteroid = obj.GetComponent<Asteroid>();
        
        if(asteroid!=null)
        { 
            int depth = manager.OnDeath(asteroid.asteroidNode);
            
            if(depth <3)AsteroidSplit(asteroid.asteroidNode,depth,asteroid.transform.position);
           
        }
        else if(obj.GetComponent<UFO>())ufoCount--;

        SpaceObject spaceObj = obj.GetComponent<SpaceObject>();

        if(spaceObj)
        {
            scoreEvent.Invoke(spaceObj.score);
        }
        
    }

    void AsteroidSplit(AsteroidTreeNode node, int depth, Vector3 position)
    {

        for (int i = 0; i<3;i++)
        {
            
            GameObject obj = Instantiate(asteroidList[Settings.Singleton.MyRand(3*(depth),3*(depth)+2)],position,Quaternion.identity);
            Asteroid asteroid =obj.GetComponent<Asteroid>();
            
            asteroid.speedScale =depth; 
            asteroid.asteroidNode = new AsteroidTreeNode(node);
            
            asteroid.EvDeath.AddListener(OnObjectDestroy);

            manager.AddChild(node,asteroid.asteroidNode);

        }
        
    }

    void StopAllTimers()
    {
        spawnUFO.PauseTik(false);
        spawnAsteroid.Tik(false);

    }
}
