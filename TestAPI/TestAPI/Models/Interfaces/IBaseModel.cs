namespace TestAPI.Models.Interfaces;

public interface IBaseModel
{
    string ModelName { get; }

    int Id { get; set; }

    void InitializeNew(string userName);

    void SetInfoForUpdatedInstance(string userName);

    TModel ShallowCopy<TModel>();
}
