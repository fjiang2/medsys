
namespace Sys.Data.Manager
{
    
    public abstract class Migration
    {
        private MigrationProvider provider;

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

        public MigrationProvider Database
        {
            get { return provider; }
            set { provider = value; }
        }

        public virtual void InitializeOnce(string[] args)
        {
        }
    }
}
