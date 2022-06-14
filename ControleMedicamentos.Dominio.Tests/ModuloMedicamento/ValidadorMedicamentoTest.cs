using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloFornecedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloMedicamento
{
    [TestClass]
    public class ValidadorMedicamentoTest
    {
        private Medicamento medicamento;
        private ValidadorMedicamento validadorMedicamento;
        private Fornecedor fornecedor;

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
        public void Nome_nao_deve_ser_nulo()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = null;
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = "231AS1";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Nome_nao_deve_ser_vazio()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "";
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = "231AS1";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Nome_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Do";
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = "231AS1";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Descricao_nao_deve_ser_nulo()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Doril";
            medicamento.Descricao = null;
            medicamento.Lote = "231AS1";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Descricao_nao_deve_ser_vazio()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Doril";
            medicamento.Descricao = "";
            medicamento.Lote = "231AS1";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Descricao_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Do";
            medicamento.Descricao = "To";
            medicamento.Lote = "231AS1";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Lote_nao_deve_ser_nulo()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Doril";
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = null;
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Lote_nao_deve_ser_vazio()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Doril";
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = "";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Lote_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Do";
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = "23";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Validade_deve_ser_criada()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Doril";
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = "231AS1";
            medicamento.QuantidadeDisponivel= 10;
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Quantidade_deve_ser_criada()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Doril";
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = "231AS1";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);    
            medicamento.Fornecedor = fornecedor;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Fornecedor_nao_deve_ser_nulo()
        {
            //arrange
            Fornecedor fornecedor = gerarFornecedor();

            Medicamento medicamento = new Medicamento();
            medicamento.Nome = "Doril";
            medicamento.Descricao = "Tomou doril a dor sumiu.";
            medicamento.Lote = "231AS1";
            medicamento.Validade = new DateTime(2022, 01, 09, 09, 15, 00);
            medicamento.QuantidadeDisponivel = 10;
            medicamento.Fornecedor = null;

            validadorMedicamento = new ValidadorMedicamento();

            //action
            var resutadoValidacao = validadorMedicamento.Validate(medicamento);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }
    }
}
