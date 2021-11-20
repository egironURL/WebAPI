using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        //GET api/ObtenerMensajes
        [HttpGet]
        public string ObtenerMensajes()
        {
            var CurrentDir = Directory.GetCurrentDirectory();
            string pathfile = CurrentDir + @"\App_Data\Messages.json";
            string jsonString = string.Empty;

            if (!System.IO.File.Exists(pathfile))
            {
                System.IO.File.Create(pathfile);
            }
            else
            {
                StreamReader r = new StreamReader(pathfile);
                jsonString = r.ReadToEnd();
                r.Close();
            }

            return jsonString;
        }


        //POST api/GuardarMensajes
        [HttpPost]
        public void GuardarMensajes(int llave, Chats chatsOriginal)
        {
            Data dataMessage = new Data();
            var CurrentDir = Directory.GetCurrentDirectory();
            string pathfileDirectory = CurrentDir + "\\App_Data";
            string pathfile = CurrentDir + CurrentDir + "\\App_Data\\Messages.json";

            if (!System.IO.Directory.Exists(pathfileDirectory))
            {
                DirectoryInfo di = Directory.CreateDirectory(pathfileDirectory);
            }
            if (!System.IO.File.Exists(pathfile))
            {
                System.IO.File.Create(pathfile);
            }
            StreamReader r = new StreamReader(pathfile);
            string jsonString = r.ReadToEnd();
            if(jsonString != string.Empty)
            {
                dataMessage = JsonConvert.DeserializeObject<Data>(jsonString);
            }
            r.Close ();

            dataMessage.AgregarChat(llave, chatsOriginal);
            StreamWriter sw = new StreamWriter(pathfile);

            string chatsJsonFile = JsonConvert.SerializeObject(dataMessage, Formatting.Indented);
            sw.WriteLine(chatsJsonFile);
            sw.Close();
        }
    }
}
