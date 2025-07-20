namespace Common.Pool
{
    using UnityEngine;
    using UnityEngine.Pool;

    public class PooledComponent : MonoBehaviour
    {
        private IObjectPool<PooledComponent> _pool;

        public virtual void Initialize(IObjectPool<PooledComponent> pool) =>
            _pool = pool;

        public virtual void Release() =>
            _pool.Release(this);
    }
}
