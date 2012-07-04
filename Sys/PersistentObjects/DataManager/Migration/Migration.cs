
namespace Sys.DataManager
{
    
    public abstract class Migration
    {
        private Provider provider;

        public string Name
        {
            get { return GetType().Name; }
        }

        public abstract void Up();

        public virtual void AfterUp()
        {
        }

        public abstract void Down();

        public virtual void AfterDown()
        {
        }

        public Provider Database
        {
            get { return provider; }
            set { provider = value; }
        }

        public virtual void InitializeOnce(string[] args)
        {
        }
    }
}
