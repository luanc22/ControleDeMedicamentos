using ControleMedicamentos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        private Funcionario funcionario;
        private ValidadorFuncionario validadorFuncionario;

        [TestMethod]
        public void Nome_nao_deve_ser_nulo()
        {
            //arrange
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = null;
            funcionario.Login = "loginteste";
            funcionario.Senha = "senhateste";

            validadorFuncionario = new ValidadorFuncionario();

            //action
            var resutadoValidacao = validadorFuncionario.Validate(funcionario);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Nome_nao_deve_ser_vazio()
        {
            //arrange
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "";
            funcionario.Login = "loginteste";
            funcionario.Senha = "senhateste";

            validadorFuncionario = new ValidadorFuncionario();

            //action
            var resutadoValidacao = validadorFuncionario.Validate(funcionario);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Nome_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "No";
            funcionario.Login = "loginteste";
            funcionario.Senha = "senhateste";

            validadorFuncionario = new ValidadorFuncionario();

            //action
            var resutadoValidacao = validadorFuncionario.Validate(funcionario);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Login_nao_deve_ser_nulo()
        {
            //arrange
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Luan";
            funcionario.Login = null;
            funcionario.Senha = "senhateste";

            validadorFuncionario = new ValidadorFuncionario();

            //action
            var resutadoValidacao = validadorFuncionario.Validate(funcionario);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Login_nao_deve_ser_vazio()
        {
            //arrange
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Luan";
            funcionario.Login = "";
            funcionario.Senha = "senhateste";

            validadorFuncionario = new ValidadorFuncionario();

            //action
            var resutadoValidacao = validadorFuncionario.Validate(funcionario);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Login_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Luan";
            funcionario.Login = "Lo";
            funcionario.Senha = "senhateste";

            validadorFuncionario = new ValidadorFuncionario();

            //action
            var resutadoValidacao = validadorFuncionario.Validate(funcionario);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Senha_nao_deve_ser_nulo()
        {
            //arrange
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Luan";
            funcionario.Login = "loginteste";
            funcionario.Senha = null;

            validadorFuncionario = new ValidadorFuncionario();

            //action
            var resutadoValidacao = validadorFuncionario.Validate(funcionario);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Senha_nao_deve_ser_vazio()
        {
            //arrange
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Luan";
            funcionario.Login = "loginteste";
            funcionario.Senha = "";

            validadorFuncionario = new ValidadorFuncionario();

            //action
            var resutadoValidacao = validadorFuncionario.Validate(funcionario);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }

        [TestMethod]
        public void Senha_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Luan";
            funcionario.Login = "loginteste";
            funcionario.Senha = "s";

            validadorFuncionario = new ValidadorFuncionario();

            //action
            var resutadoValidacao = validadorFuncionario.Validate(funcionario);

            //assert
            Assert.AreEqual(false, resutadoValidacao.IsValid);
        }




    }
}
