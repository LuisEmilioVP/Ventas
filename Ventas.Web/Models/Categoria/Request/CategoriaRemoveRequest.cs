namespace Ventas.Web.Models.Categoria.Request
{
    public class CategoriaRemoveRequest : BaseRequest
    {
        public int IdCategoria { get; set; }
        public bool Deleted { get; set; }

        public CategoriaRemoveRequest()
        {
        }

        public CategoriaRemoveRequest(int idCategory)
        {
            this.IdCategoria = idCategory;
            this.Deleted = true;
        }
    }
}
