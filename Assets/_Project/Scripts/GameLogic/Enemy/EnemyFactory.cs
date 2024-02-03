using UnityEngine;
using UnityEngine.Splines;

namespace ShootEmUp
{
    public class EnemyFactory
    {
        EnemyBuilder enemyBuilder;
        public GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline)
        {
            enemyBuilder ??= new EnemyBuilder();

            enemyBuilder
                .SetBasePrefab(enemyType.enemyPrefab)
                .SetSpline(spline)
                .SetSpeed(enemyType.speed)
                .SetWeaponStrategy(enemyType.enemyWeapon);

            return enemyBuilder.Build();
        }
        
        // More factory methods, for example enemies that do not follow a spline
    }
}
