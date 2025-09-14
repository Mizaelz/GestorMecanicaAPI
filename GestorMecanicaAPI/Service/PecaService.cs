using GestorMecanicaAPI.Exceptions;
using GestorMecanicaAPI.Infrastructure.Repository;
using GestorMecanicaAPI.Model;

namespace GestorMecanicaAPI.Service
{
    public class PecaService
    {
        private readonly PecaRepository _pecaRepository;
        public PecaService(PecaRepository pecaRepository)
        {
            _pecaRepository = pecaRepository;
        }

        public void CadastraPeca(PecaModel pecaModel)
        {
            bool numeroPecaExistente = _pecaRepository.VerificaPeca(pecaModel.NumeroPeca);
            if (numeroPecaExistente) throw new BusinessException("Número da peça já cadastrado");
            _pecaRepository.CadastraPeca(pecaModel);
        }
        public void ExcluiPeca(int pecaId) => _pecaRepository.ExcluiPeca(pecaId);
        public IEnumerable<PecaModel> BuscaPecas() => _pecaRepository.BuscaPecas();
    }
}
