namespace TraineesApp.DBServices_Repo_
{
    //for many to many relationship table
    public interface IDBManyRepo<TEntity>
    {
        public TEntity GetById(int id ,int id2);
        public List<TEntity> GetAll();
        public void Add(TEntity entity);
        public void Update(int id,int id2, TEntity entity);
        public void Delete(int id, int id2);
    }
}
