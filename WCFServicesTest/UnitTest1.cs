using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1CrearClienteOk()
        {
            ClientesWS.ClientesClient proxy = new ClientesWS.ClientesClient();
            ClientesWS.Cliente clienteCreado = proxy.CrearCliente(new ClientesWS.Cliente()
            {
                IdCliente = 6,
                Nombre = "Lisa",
                ApellidoPaterno = "Roman",
                ApellidoMaterno = "Poma",
                Sexo = "F",
                Dni = 12312340,
                CorreoElectronico = "lroman@gmail.com",
                Contraseña = "246753",
                Celular= 999888997,
                Direccion = "Av. Javier Prado 657"

            });
            Assert.AreEqual(6, clienteCreado.IdCliente);
            Assert.AreEqual("Lisa", clienteCreado.Nombre);
            Assert.AreEqual("Roman", clienteCreado.ApellidoPaterno);
            Assert.AreEqual("Poma", clienteCreado.ApellidoMaterno);
            Assert.AreEqual("F", clienteCreado.Sexo);
            Assert.AreEqual(12312340, clienteCreado.Dni);
            Assert.AreEqual("lroman@gmail.com", clienteCreado.CorreoElectronico);
            Assert.AreEqual("246753", clienteCreado.Contraseña);
            Assert.AreEqual(999888997, clienteCreado.Celular);
            Assert.AreEqual("Av. Javier Prado 657", clienteCreado.Direccion);
        }

        [TestMethod]
        public void Test2CrearClienteRepetido()
        {
            ClientesWS.ClientesClient proxy = new ClientesWS.ClientesClient();
            try
            {
                ClientesWS.Cliente clienteCreado = proxy.CrearCliente(new ClientesWS.Cliente()
                {
                    IdCliente = 0,
                    Nombre = "Luna",
                    ApellidoPaterno = "Rosas",
                    ApellidoMaterno = "Hidalgo",
                    Sexo = "F",
                    Dni = 12312345,
                    CorreoElectronico = "lrosas@gmail.com",
                    Contraseña = "tyu123",
                    Celular = 999888999,
                    Direccion = "Av. Javier Prado 345"
                });
            }catch(FaultException<ClientesWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar crear cliente", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El cliente ya existe");
            }
        }
    }
}
