namespace SubApplication;

public interface ICrud<TRoot, TId>
{
	Task<bool> Add(TRoot root);
	Task<bool> Delete(TId id);
	Task<bool> Update(TRoot root);
	Task<TRoot?> Get(TId id);
	Task<IEnumerable<TRoot>> GetAll();
}
