using Microsoft.AspNetCore.Mvc;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System;
using System.Collections.Generic;
using System.Net;

namespace SnmpApi.EndPoints
{
    public class DeviceController : ControllerBase
    {
        private const string Community = "public";

        [HttpGet("/devices/{ip}")]
        public IActionResult GetValue(string ip, [FromQuery] string oidWrite)
        {
            if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(oidWrite))
            {
                return BadRequest("IP e OID são obrigatórios.");
            }

            try
            {
                var oid = new List<Variable> { new Variable(new ObjectIdentifier(oidWrite)) };
                // Enviar a requisição SNMP
                var result = Messenger.Get(VersionCode.V2,
                                           new IPEndPoint(IPAddress.Parse(ip), 161),
                                           new OctetString(Community),
                                           oid,
                                           6000);

                if (result != null && result.Count > 0)
                {
                    // Extrair o valor da resposta
                    var value = result[0].Data.ToString();
                    return Ok(value);
                }
                else
                {
                    return NotFound("OID não encontrada ou sem resposta.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao consultar SNMP: {ex.Message}");
            }
        }
    }
}
