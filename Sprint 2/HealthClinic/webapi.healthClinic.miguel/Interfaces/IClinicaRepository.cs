using webapi.healthClinic.miguel.Domains;

namespace webapi.healthClinic.miguel.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica c);
        void Deletar(Guid id);
    }
}
