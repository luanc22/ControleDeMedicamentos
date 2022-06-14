using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Dominio.ModuloRequisicao;
using ControleMedicamentos.Dominio.ModuloFornecedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloRequisicao
{
    [TestClass]
    public class ValidadorMedicamentoTest
    {
        private Requisicao requisicao;
        private ValidadorRequisicao validadorRequisicao;
        private Funcionario funcionario;
        private Medicamento medicamento;
        private Paciente paciente;
        private Fornecedor fornecedor;

        public Medicamento gerarMedicamento()
        {
            Fornecedor fornecedor = gerarFornecedor();
            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Doril";
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = "231AS1";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = fornecedor;

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
        public void Medicamento_nao_deve_ser_nulo()
        {
            Requisicao requisicao = new Requisicao();
            requisicao.Medicamento = null;
            requisicao.Paciente = gerarPaciente();
            requisicao.Funcionario = gerarFuncionario();
            requisicao.Data = new DateTime(2022, 01, 09, 09, 15, 00);
            requisicao.QtdMedicamento = 2;

            validadorRequisicao = new ValidadorRequisicao();

            //action
            var resutadoValidacao = validadorRequisicao.Validate(requisicao);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Paciente_nao_deve_ser_nulo()
        {
            Requisicao requisicao = new Requisicao();
            requisicao.Medicamento = gerarMedicamento();
            requisicao.Paciente = null;
            requisicao.Funcionario = gerarFuncionario();
            requisicao.Data = new DateTime(2022, 01, 09, 09, 15, 00);
            requisicao.QtdMedicamento = 2;

            validadorRequisicao = new ValidadorRequisicao();

            //action
            var resutadoValidacao = validadorRequisicao.Validate(requisicao);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Funcionario_nao_deve_ser_nulo()
        {
            Requisicao requisicao = new Requisicao();
            requisicao.Medicamento = gerarMedicamento();
            requisicao.Paciente = gerarPaciente();
            requisicao.Funcionario = null;
            requisicao.Data = new DateTime(2022, 01, 09, 09, 15, 00);
            requisicao.QtdMedicamento = 2;

            validadorRequisicao = new ValidadorRequisicao();

            //action
            var resutadoValidacao = validadorRequisicao.Validate(requisicao);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Data_deve_ser_criada()
        {
            Requisicao requisicao = new Requisicao();
            requisicao.Medicamento = gerarMedicamento();
            requisicao.Paciente = gerarPaciente();
            requisicao.Funcionario = gerarFuncionario();
            requisicao.QtdMedicamento = 2;

            validadorRequisicao = new ValidadorRequisicao();

            //action
            var resutadoValidacao = validadorRequisicao.Validate(requisicao);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void QtdMedicamento_deve_ser_criada()
        {
            Requisicao requisicao = new Requisicao();
            requisicao.Medicamento = gerarMedicamento();
            requisicao.Paciente = gerarPaciente();
            requisicao.Funcionario = gerarFuncionario();
            requisicao.Data = new DateTime(2022, 01, 09, 09, 15, 00);

            validadorRequisicao = new ValidadorRequisicao();

            //action
            var resutadoValidacao = validadorRequisicao.Validate(requisicao);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void QtdMedicamento_deve_ser_maior_que_0()
        {
            Requisicao requisicao = new Requisicao();
            requisicao.Medicamento = gerarMedicamento();
            requisicao.Paciente = gerarPaciente();
            requisicao.Funcionario = gerarFuncionario();
            requisicao.Data = new DateTime(2022, 01, 09, 09, 15, 00);
            requisicao.QtdMedicamento = 0;

            validadorRequisicao = new ValidadorRequisicao();

            //action
            var resutadoValidacao = validadorRequisicao.Validate(requisicao);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }
    }
}

