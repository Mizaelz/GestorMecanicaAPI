using Dapper;
using GestorMecanicaAPI.Infrastructure.Data;
using GestorMecanicaAPI.Model;
using Microsoft.Data.SqlClient;

namespace GestorMecanicaAPI.Infrastructure.Repository
{
    public class PecaRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;
        public PecaRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void CadastraPeca(PecaModel pecaModel)
        {
            var sql = @"
                Insert into Peca
                (
                    NomePeca,
                    NumeroPeca,
                    CategoriaPeca,
                    Fabricante,
                    Preco
                    
                )
                values
                (
                    @NomePeca,                    
                    @NumeroPeca,
                    @CategoriaPeca,
                    @Fabricante,
                    @Preco                                       
                )";

            using (var db = _dbConnectionFactory.CreateConnection())
            {
                db.Execute(sql, param: new
                {
                    pecaModel.NomePeca,
                    pecaModel.NumeroPeca,
                    pecaModel.CategoriaPeca,
                    pecaModel.Fabricante,
                    pecaModel.Preco
                });
            }
        }

        public void ExcluiPeca(int pecaId)
        {
            var sql = @"Delete from peca where Id = @pecaId";

            using (var db = _dbConnectionFactory.CreateConnection())
            {
                db.Execute(sql, param: new { pecaId });
            }
        }

        public IEnumerable<PecaModel> BuscaPecas()
        {
            var sql = @"select * from peca";

            using (var db = _dbConnectionFactory.CreateConnection())
            {
                return db.Query<PecaModel>(sql);
            }
        }

        public bool VerificaPeca(int pecaId)
        {
            var sql = @"select 1 from peca where numeroPeca = @pecaId";

            using (var db = _dbConnectionFactory.CreateConnection())
            {
                return db.QueryFirstOrDefault<bool>(sql, param: new { pecaId });
            }
        }
    }
}
