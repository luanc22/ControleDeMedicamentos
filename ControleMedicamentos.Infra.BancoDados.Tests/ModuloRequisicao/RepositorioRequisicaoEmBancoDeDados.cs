using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Dominio.ModuloRequisicao;
using ControleMedicamentos.Infra.BancoDados.ModuloPaciente;
using ControleMedicamentos.Infra.BancoDados.ModuloFuncionario;
using ControleMedicamentos.Infra.BancoDados.ModuloFornecedor;
using ControleMedicamento.Infra.BancoDados.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados.ModuloRequisicao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloRequisicao
{
    [TestClass]
    public class RepositorioPacienteEmBancoDadosTest
    {
        private Requisicao requisicao;
        private RepositorioRequisicaoEmBancoDados repositorioRequisicao;
        private Medicamento medicamento;
        private RepositorioMedicamentoEmBancoDados repositorioMedicamento;
        private Fornecedor fornecedor;
        private RepositorioFornecedorEmBancoDados repositorioFornecedor;
        private Funcionario funcionario;
        private RepositorioFuncionarioEmBancoDados repositorioFuncionario;
        private Paciente paciente;
        private RepositorioPacienteEmBancoDados repositorioPaciente;

        public RepositorioPacienteEmBancoDadosTest()
        {
            DataBase.ExecutarSql(@"DELETE FROM TBREQUISICAO;
                  DBCC CHECKIDENT (TBREQUISICAO, RESEED, 0)
                  DELETE FROM TBMEDICAMENTO;
                  DBCC CHECKIDENT (TBMEDICAMENTO, RESEED, 0)
                  DELETE FROM TBFUNCIONARIO;
                  DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)
                  DELETE FROM TBPACIENTE;
                  DBCC CHECKIDENT (TBPACIENTE, RESEED, 0)");

            medicamento = gerarMedicamento();
            fornecedor = gerarFornecedor();
            paciente = gerarPaciente();
            funcionario = gerarFuncionario();
            requisicao = gerarRequisicao();

            medicamento.Fornecedor = fornecedor;
            requisicao.Medicamento = medicamento;
            requisicao.Funcionario = funcionario;
            requisicao.Paciente = paciente;

            repositorioMedicamento = new RepositorioMedicamentoEmBancoDados();
            repositorioFornecedor = new RepositorioFornecedorEmBancoDados();
            repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            repositorioPaciente = new RepositorioPacienteEmBancoDados();
            repositorioRequisicao = new RepositorioRequisicaoEmBancoDados();

        }

        public Requisicao gerarRequisicao()
        {
            Requisicao requisicao = new Requisicao();
            requisicao.Data = new DateTime(2022, 01, 09, 09, 15, 00);
            requisicao.QtdMedicamento = 2;

            return requisicao;
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

        public Paciente gerarPaciente()
        {
            Paciente paciente = new Paciente();
            paciente.Nome = "Luan";
            paciente.CartaoSUS = "1322131231";

            return paciente;
        }

        public Funcionario gerarFuncionario()
        {
            Funcionario funcionario = new Funcionario();
            funcionario.Login = "loginteste";
            funcionario.Senha = "senhateste";
            funcionario.Nome = "nometeste";

            return funcionario;
        }

        [TestMethod]
        public void Deve_inserir_nova_requisicao()
        {
            //action
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);
            repositorioFuncionario.Inserir(funcionario);
            repositorioPaciente.Inserir(paciente);
            repositorioRequisicao.Inserir(requisicao);

            //assert
            var requisicaoEncontrada = repositorioRequisicao.SelecionarPorNumero(requisicao.id);

            Assert.IsNotNull(requisicaoEncontrada);
            Assert.AreEqual(requisicao, requisicaoEncontrada);
        }

        [TestMethod]
        public void Deve_editar_informacoes_requisicao()
        {
            //arrange                      
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);
            repositorioFuncionario.Inserir(funcionario);
            repositorioPaciente.Inserir(paciente);
            repositorioRequisicao.Inserir(requisicao);

            //action
            requisicao.QtdMedicamento = 5;
            repositorioRequisicao.Editar(requisicao);

            //assert
            var requisicaoEncontrada = repositorioRequisicao.SelecionarPorNumero(requisicao.id);

            Assert.IsNotNull(requisicaoEncontrada);
            Assert.AreEqual(requisicao, requisicaoEncontrada);
        }

        [TestMethod]
        public void Deve_excluir_requisicao()
        {
            //arrange           
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);
            repositorioFuncionario.Inserir(funcionario);
            repositorioPaciente.Inserir(paciente);
            repositorioRequisicao.Inserir(requisicao);

            //action           
            repositorioRequisicao.Excluir(requisicao);

            //assert
            var requisicaoEncontrada = repositorioRequisicao.SelecionarPorNumero(requisicao.id);
            Assert.IsNull(requisicaoEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_uma_requisicao()
        {
            //arrange          
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);
            repositorioFuncionario.Inserir(funcionario);
            repositorioPaciente.Inserir(paciente);
            repositorioRequisicao.Inserir(requisicao);

            //action
            var requisicaoEncontrada = repositorioRequisicao.SelecionarPorNumero(requisicao.id);

            //assert
            Assert.IsNotNull(requisicaoEncontrada);
            Assert.AreEqual(requisicao, requisicaoEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_todos_as_requisicoes()
        {
            //arrange
            repositorioFornecedor.Inserir(fornecedor);
            repositorioMedicamento.Inserir(medicamento);
            repositorioFuncionario.Inserir(funcionario);
            repositorioPaciente.Inserir(paciente);
            var requisicao1 = new Requisicao(medicamento, paciente, 3, new DateTime(2022, 01, 09, 09, 15, 00), funcionario);
            var requisicao2 = new Requisicao(medicamento, paciente, 7, new DateTime(2022, 03, 09, 09, 15, 00), funcionario);

            repositorioRequisicao.Inserir(requisicao1);
            repositorioRequisicao.Inserir(requisicao2);

            //action
            var requisicoes = repositorioRequisicao.SelecionarTodos();

            //assert

            Assert.AreEqual(2, requisicoes.Count);

            Assert.AreEqual(requisicao1.Paciente.Nome, requisicoes[0].Paciente.Nome);
            Assert.AreEqual(requisicao2.Paciente.Nome, requisicoes[1].Paciente.Nome);

        }
    }
}
