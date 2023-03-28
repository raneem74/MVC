namespace TraineesApp.DBServices_Repo_
{
    public interface IDBRepo<TEntity> where TEntity : class
    {
        public TEntity GetById(int id);
        public List<TEntity> GetAll();
        public void Add(TEntity entity);
        public void Update(int id , TEntity entity);
        public void Delete(int id);

    }
}
