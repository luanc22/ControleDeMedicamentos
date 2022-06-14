﻿using ControleMedicamentos.Dominio.ModuloFornecedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloFornecedor
{
    [TestClass]
    public class ValidadorFornecedorTest
    {
        private Fornecedor fornecedor;
        private ValidadorFornecedor validadorFornecedor;

        [TestMethod]
        public void Nome_nao_deve_ser_nulo()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = null;
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Nome_nao_deve_ser_vazio()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "";
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Nome_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "No";
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Telefone_nao_deve_ser_nulo()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = null;
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Telefone_nao_deve_ser_vazio()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Telefone_deve_ter_no_minimo_9_caracteres()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Telefone_deve_ter_no_maximo_11_caracteres()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "9999999999999999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
]        public void Email_nao_deve_ser_nulo()
        {
            //arrange
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "9999999999";
            fornecedor.Email = null;
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Email_nao_deve_ser_vazio()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Email_deve_ter_no_minimo_5_caracteres()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "emai";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Cidade_nao_deve_ser_nulo()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = null;
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Cidade_nao_deve_ser_vazio()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Cidade_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "La";
            fornecedor.Estado = "SC";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Estado_nao_deve_ser_nulo()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = null;

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Estado_nao_deve_ser_vazio()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }

        [TestMethod]
        public void Nome_deve_ter_no_minimo_2_caracteres()
        {
            //arrange
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Nome";
            fornecedor.Telefone = "99999999";
            fornecedor.Email = "fornecedor@email.com";
            fornecedor.Cidade = "Lages";
            fornecedor.Estado = "S";

            validadorFornecedor = new ValidadorFornecedor();

            //action
            var resultadoValidacao = validadorFornecedor.Validate(fornecedor);

            //assert
            Assert.AreEqual(false, resultadoValidacao.IsValid);
        }
    }
}
