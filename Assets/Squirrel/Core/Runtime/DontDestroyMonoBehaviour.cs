namespace Squirrel
{
    public class DontDestroyMonoBehaviour<T> : SingletonProtected<T> where T : DontDestroyMonoBehaviour<T>
    {
        protected override void Awake()
        {
            base.Awake();
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
    }
}