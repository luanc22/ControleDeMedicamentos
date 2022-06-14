using ControleMedicamentos.Dominio.ModuloPaciente;
using ControleMedicamentos.Infra.BancoDados.ModuloPaciente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloPaciente
{
    [TestClass]
    public class RepositorioPacienteEmBancoDadosTest
    {
        private Paciente paciente;
        private RepositorioPacienteEmBancoDados repositorio;

        public RepositorioPacienteEmBancoDadosTest()
        {
            DataBase.ExecutarSql("DELETE FROM TBPACIENTE; DBCC CHECKIDENT (TBPACIENTE, RESEED, 0)");

            paciente = gerarPaciente();
            repositorio = new RepositorioPacienteEmBancoDados();
        }

        public Paciente gerarPaciente()
        {
            Paciente paciente = new Paciente();
            paciente.Nome = "Luan";
            paciente.CartaoSUS = "1322131231";

            return paciente;
        }

        [TestMethod]
        public void Deve_inserir_novo_paciente()
        {
            //action
            repositorio.Inserir(paciente);

            //assert
            var pacienteEncontrado = repositorio.SelecionarPorNumero(paciente.id);

            Assert.IsNotNull(pacienteEncontrado);
            Assert.AreEqual(paciente, pacienteEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_paciente()
        {
            //arrange                      
            repositorio.Inserir(paciente);

            //action
            paciente.Nome = "Luan Cabral";
            paciente.CartaoSUS = "132213123123";
            repositorio.Editar(paciente);

            //assert
            var pacienteEncontrado = repositorio.SelecionarPorNumero(paciente.id);

            Assert.IsNotNull(pacienteEncontrado);
            Assert.AreEqual(paciente, pacienteEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_paciente()
        {
            //arrange           
            repositorio.Inserir(paciente);

            //action           
            repositorio.Excluir(paciente);

            //assert
            var pacienteEncontrado = repositorio.SelecionarPorNumero(paciente.id);
            Assert.IsNull(pacienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_paciente()
        {
            //arrange          
            repositorio.Inserir(paciente);

            //action
            var pacienteEncontrado = repositorio.SelecionarPorNumero(paciente.id);

            //assert
            Assert.IsNotNull(pacienteEncontrado);
            Assert.AreEqual(paciente, pacienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_pacientes()
        {
            //arrange
            var paciente1 = new Paciente("Anderson Silva", "1231321313");
            var paciente2 = new Paciente("Jose Otavio", "32132132111");


            var repositorio = new RepositorioPacienteEmBancoDados();
            repositorio.Inserir(paciente1);
            repositorio.Inserir(paciente2);

            //action
            var pacientes = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(2, pacientes.Count);

            Assert.AreEqual(paciente1.Nome, pacientes[0].Nome);
            Assert.AreEqual(paciente2.Nome, pacientes[1].Nome);
        }
    }
}

