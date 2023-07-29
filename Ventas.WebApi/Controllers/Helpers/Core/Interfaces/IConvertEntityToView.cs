namespace Ventas.WebApi.Controllers.Helpers.Core.Interfaces
{
    public interface IConvertEntityToView<TResultView, TFrom>
    {
        TResultView Convert(TFrom from);
    }
}
