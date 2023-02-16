using TestAPI.Models.Interfaces;

namespace TestAPI.Models;

public class BaseModel : IBaseModel
{
    public string ModelName => this.GetType().Name.Replace("Model", string.Empty);
    public virtual int Id { get; set; }

    public virtual void InitializeNew(string userName)
    {

    }

    public void SetInfoForUpdatedInstance(string userName)
    {
        throw new NotImplementedException();
    }

    public TModel ShallowCopy<TModel>()
    {
        return (TModel)this.MemberwiseClone();
    }
}
