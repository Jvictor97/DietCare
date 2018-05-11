namespace DietCareDDD.MVC.ViewModels
{
    public class public class ClasseAlimentarViewModel
    {
        public string classe_tipo { get; set; }

        // Relacionamentos:
        public int id_usu { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
    }
}