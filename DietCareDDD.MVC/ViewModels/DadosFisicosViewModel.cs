namespace DietCareDDD.MVC.ViewModels
{
    public class DadosFisicosViewModel
    {
        public float dados_peso { get; set; }

        public float dados_altura { get; set; }

        public int dados_idade { get; set; }

        // Relacionamentos:
        public int id_usu { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
    }
}