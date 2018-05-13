using AutoMapper;
using DietCareDDD.Domain.Entities;
using DietCareDDD.MVC.ViewModels;

namespace DietCareDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AlimentoViewModel,         Alimento>();
            Mapper.CreateMap<ClasseAlimentarViewModel,  ClasseAlimentar>();
            Mapper.CreateMap<DadosFisicosViewModel,     DadosFisicos>();
            Mapper.CreateMap<DiarioViewModel,           Diario>();
            Mapper.CreateMap<MetaViewModel,             Meta>();
            Mapper.CreateMap<RefeicaoAlimentoViewModel, RefeicaoAlimento>();
            Mapper.CreateMap<RefeicaoViewModel,         Refeicao>();
            Mapper.CreateMap<RestricaoViewModel,        Restricao>();
            Mapper.CreateMap<UnidadeViewModel,          Unidade>();
            Mapper.CreateMap<UsuarioViewModel,          Usuario>();
        }

    }
}