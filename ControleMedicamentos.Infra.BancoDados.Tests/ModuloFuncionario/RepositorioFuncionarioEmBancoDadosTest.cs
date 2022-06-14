using ControleMedicamentos.Dominio.ModuloFuncionario;
using ControleMedicamentos.Infra.BancoDados.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmBancoDadosTest
    {
        private Funcionario funcionario;
        private RepositorioFuncionarioEmBancoDados repositorio;

        public RepositorioFuncionarioEmBancoDadosTest()
        {
            DataBase.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)");

            funcionario = gerarFuncionario();
            repositorio = new RepositorioFuncionarioEmBancoDados();
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
        public void Deve_inserir_novo_funcionario()
        {
            //action
            repositorio.Inserir(funcionario);

            //assert
            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.id);

            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_funcionario()
        {
            //arrange                      
            repositorio.Inserir(funcionario);

            //action
            funcionario.Nome = "Nome Teste";
            funcionario.Login = "login.teste";
            funcionario.Senha = "senha.teste";
            repositorio.Editar(funcionario);

            //assert
            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.id);

            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange           
            repositorio.Inserir(funcionario);

            //action           
            repositorio.Excluir(funcionario);

            //assert
            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.id);
            Assert.IsNull(funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_funcionario()
        {
            //arrange          
            repositorio.Inserir(funcionario);

            //action
            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.id);

            //assert
            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_funcionarios()
        {
            //arrange
            var funcionario1 = new Funcionario("Nome Teste2", "login.teste2" , "senha.teste2");
            var funcionario2 = new Funcionario("Nome Teste3", "login.teste3", "senha.teste3");

            var repositorio = new RepositorioFuncionarioEmBancoDados();
            repositorio.Inserir(funcionario1);
            repositorio.Inserir(funcionario2);

            //action
            var funcionarios = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(2, funcionarios.Count);

            Assert.AreEqual(funcionario1.Nome, funcionarios[0].Nome);
            Assert.AreEqual(funcionario2.Nome, funcionarios[1].Nome);
 
        }
    }
}
