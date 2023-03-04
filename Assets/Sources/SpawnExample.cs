using UnityEngine;
using Asteroids.Model;


public class SpawnExample : MonoBehaviour
{
    [SerializeField] private PresentersFactory _factory;
    [SerializeField] private Root _init;

    private int _index;
    private float _secondsPerIndex = 1f;

    private Army _firstArmy, _secondArmy;

    private void Start()
    {
        _firstArmy = new Army();
        _secondArmy = new Army();

        for(int i = 0; i < 100; i++)
        {
            Nlo nloFromFirstTeam = new Nlo(null, GetRandomPositionOutsideScreen(), Config.NloSpeed);
            Nlo nloFromSecondTeam = new Nlo(null, GetRandomPositionOutsideScreen(), Config.NloSpeed);

            _secondArmy.AddNewNlo(nloFromFirstTeam);
            _secondArmy.AddNewNlo(nloFromSecondTeam);
            nloFromFirstTeam.SetEnemy(nloFromSecondTeam);
            nloFromSecondTeam.SetEnemy(nloFromFirstTeam);
            _factory.CreateNlo(nloFromFirstTeam, Color.blue);
            _factory.CreateNlo(nloFromFirstTeam,Color.red);
        }

    }

    private void Update()
    {
        int newIndex = (int)(Time.time / _secondsPerIndex);

        if(newIndex > _index)
        {
            _index = newIndex;
            OnTick();
        }
    }

    private void OnTick()
    {
        float chance = Random.Range(0, 100);

        if (chance < 20)
        {
            Vector2 position = GetRandomPositionOutsideScreen();
            Vector2 direction = GetDirectionThroughtScreen(position);

            _factory.CreateAsteroid(new Asteroid(position, direction, Config.AsteroidSpeed));
        }
    }

    private Vector2 GetRandomPositionOutsideScreen()
    {
        return Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
    }

    private static Vector2 GetDirectionThroughtScreen(Vector2 postion)
    {
        return (new Vector2(Random.value, Random.value) - postion).normalized;
    }
}
