using Asteroids.Model;
using System.Collections;
using UnityEngine;

public class EnemyPresenter : Presenter
{
    [SerializeField] private SpriteRenderer _renderer;
    private Transformable _transform;
    private Transformable _target;

    public void Initiate(Transformable transformable, Transformable target, Color color)
    {
        _renderer.color = color;
        _transform = transformable;
        _target = target;

        StartCoroutine(CheckHit());
    }

    private IEnumerator CheckHit()
    {
        while (true)
        {
            if (Vector3.SqrMagnitude(_target.Position - _transform.Position) < 0.001f)
            {
                DestroyCompose();
                yield break;
            }
            
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyCompose();
        }
    }
}
