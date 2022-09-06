using ADN.Domain.Domain;
using ADN.Domain.Interfaces.Repositorio;
using ADN.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace ADN.Service.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _repositorio;
        private readonly ILogger<PedidoService> _log;

        public PedidoService(IPedidoRepositorio repositorio,
                             ILogger<PedidoService> log)
        {
            _repositorio = repositorio;
            _log = log;
        }

        public async Task<List<PedidoGetDTO>> GetAll()
        {
            List<PedidoGetDTO> lista = new();

            _log.LogInformation("Buscando PEDIDOS no service");
            var result = await _repositorio.GetAll();

            if (result.Any())
            {
                foreach (var item in result)
                {
                    PedidoGetDTO pedidoGet = new();
                    pedidoGet.Id = item.Id;

                    if (item.Valor != null)
                    {
                        if (IsValidJson(item.Valor))
                        {
                            pedidoGet.Valor = item.Valor.Replace("'", "\"");
                        }
                        else
                        {
                            pedidoGet.Valor = item.Valor;
                        }
                    }

                    lista.Add(pedidoGet);
                }
            }

            return lista;
        }

        public async Task Insert(Pedido pedido)
        {
            await _repositorio.Insert(pedido);
        }

        private object StringToObject(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return new BinaryFormatter().Deserialize(ms);
            }
        }

        private bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
