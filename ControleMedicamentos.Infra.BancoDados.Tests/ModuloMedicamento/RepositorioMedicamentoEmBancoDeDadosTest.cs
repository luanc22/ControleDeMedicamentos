using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamento.Infra.BancoDados.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados.ModuloFornecedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloMedicamento
{
    [TestClass]
    public class RepositorioMedicamentoEmBancoDeDadosTest
    {
        private Medicamento medicamento;
        private RepositorioMedicamentoEmBancoDados repositorioMedicamento;
        private Fornecedor fornecedor;
        private RepositorioFornecedorEmBancoDados repositorioFornecedor;

        public RepositorioMedicamentoEmBancoDeDadosTest()
        {
            DataBase.ExecutarSql("DELETE FROM TBMEDICAMENTO; DBCC CHECKIDENT (TBMEDICAMENTO, RESEED, 0)");
            DataBase.ExecutarSql("DELETE FROM TBFORNECEDOR; DBCC CHECKIDENT (TBFORNECEDOR, RESEED, 0)");

            medicamento = gerarMedicamento();
            fornecedor = gerarFornecedor();
            medicamento.Fornecedor = fornecedor;
            repositorioMedicamento = new RepositorioMedicamentoEmBancoDados();
            repositorioFornecedor = new RepositorioFornecedorEmBancoDados();
        }

        public Medicamento gerarMedicamento()
        {
            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Doril";
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = "231AS1";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;

            return medicamento;
        }

        public Fornecedor gerarFornecedor()
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Rogerio";
            fornecedor.Email = "RogerinDoYoutube@gmail.com";
            fornecedor.Telefone = "4002-8922";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            return fornecedor;
        }

        [TestMethod]
        public void Deve_inserir_novo_medicamento()
        {
            //action
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);

            //assert
            var medicamentoEncontrado = repositorioMedicamento.SelecionarPorNumero(medicamento.id);

            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(medicamento, medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_medicamento()
        {
            //arrange                      
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);

            //action
            medicamento.Nome = "Tylenol";
            medicamento.Descricao = "Contra febre";
            repositorioMedicamento.Editar(medicamento);

            //assert
            var medicamentoEncontrado = repositorioMedicamento.SelecionarPorNumero(medicamento.id);

            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(medicamento, medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_medicamento()
        {
            //arrange           
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);

            //action           
            repositorioMedicamento.Excluir(medicamento);

            //assert
            var medicamentoEncontrado = repositorioMedicamento.SelecionarPorNumero(medicamento.id);
            Assert.IsNull(medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_medicamento()
        {
            //arrange          
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);

            //action
            var medicamentoEncontrado = repositorioMedicamento.SelecionarPorNumero(medicamento.id);

            //assert
            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(medicamento, medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_medicamentos()
        {
            //arrange
            repositorioFornecedor.Inserir(fornecedor);
            var medicamento1 = new Medicamento("Neosaldina", "Contra dor de cabeça", "123SAD", new DateTime(2022, 01, 09, 09, 15, 00), 2, fornecedor);
            var medicamento2 = new Medicamento("Dipirona", "Contra dor", "1323AS", new DateTime(2022, 01, 09, 09, 15, 00), 3, fornecedor);

            repositorioMedicamento.Inserir(medicamento1);
            repositorioMedicamento.Inserir(medicamento2);

            //action
            var medicamentos = repositorioMedicamento.SelecionarTodos();

            //assert

            Assert.AreEqual(2, medicamentos.Count);

            Assert.AreEqual(medicamento1.Nome, medicamentos[0].Nome);
            Assert.AreEqual(medicamento2.Nome, medicamentos[1].Nome);

        }
    }
}
