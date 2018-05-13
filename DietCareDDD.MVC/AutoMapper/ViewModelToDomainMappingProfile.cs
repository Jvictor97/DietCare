using AutoMapper;
using DietCareDDD.Domain.Entities;
using DietCareDDD.MVC.ViewModels;

namespace DietCareDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Alimento, AlimentoViewModel>();
            Mapper.CreateMap<ClasseAlimentar, ClasseAlimentarViewModel>();
            Mapper.CreateMap<DadosFisicos, DadosFisicosViewModel>();
            Mapper.CreateMap<Diario, DiarioViewModel>();
            Mapper.CreateMap<Meta, MetaViewModel>();
            Mapper.CreateMap<RefeicaoAlimento, RefeicaoAlimentoViewModel>();
            Mapper.CreateMap<Refeicao, RefeicaoViewModel>();
            Mapper.CreateMap<Restricao, RestricaoViewModel>();
            Mapper.CreateMap<Unidade, UnidadeViewModel>();
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}